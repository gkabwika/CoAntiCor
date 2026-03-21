using CoAntiCor.Core.Domain;
using CoAntiCor.Core.Interfaces;
using CoAntiCor.Core.Model;
using CoAntiCor.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Services
{
    public class ProcessingPhaseEngine : IProcessingPhaseEngine
    {
        private readonly CoAntiCorDbContext _db;

        private static readonly Dictionary<ComplaintStatus, ComplaintStatus[]> AllowedTransitions = new()
        {
            [ComplaintStatus.Open] = new[] { ComplaintStatus.PendingEvidence, ComplaintStatus.UnderReview, ComplaintStatus.Rejected },
            [ComplaintStatus.PendingEvidence] = new[] { ComplaintStatus.UnderReview, ComplaintStatus.Rejected },
            [ComplaintStatus.UnderReview] = new[] { ComplaintStatus.Escalated, ComplaintStatus.Approved, ComplaintStatus.Rejected },
            [ComplaintStatus.Escalated] = new[] { ComplaintStatus.Approved, ComplaintStatus.Rejected },
            [ComplaintStatus.Approved] = new[] { ComplaintStatus.Closed },
            [ComplaintStatus.Rejected] = Array.Empty<ComplaintStatus>(),
            [ComplaintStatus.Closed] = Array.Empty<ComplaintStatus>()
        };

        public ProcessingPhaseEngine(CoAntiCorDbContext db)
        {
            _db = db;
        }

        public async Task ChangeStatusAsync(Guid complaintId, ComplaintStatus newStatus, Guid userId, string? comment = null)
        {
            var complaint = await _db.Complaints
                .Include(c => c.ProcessingPhases)
                .FirstOrDefaultAsync(c => c.Id == complaintId);

            if (complaint is null) throw new InvalidOperationException("Complaint not found.");

            var current = complaint.Status;

            if (!AllowedTransitions.TryGetValue(current, out var allowed) || !allowed.Contains(newStatus))
                throw new InvalidOperationException($"Transition from {current} to {newStatus} is not allowed.");

            complaint.Status = newStatus;
            complaint.UpdatedAt = DateTime.UtcNow;

            _db.ComplaintHistories.Add(new ComplaintHistory
            {
                Id = Guid.NewGuid(),
                ComplaintId = complaint.Id,
                OldStatus = current,
                NewStatus = newStatus,
                ChangedAt = DateTime.UtcNow,
                ChangedByUserId = userId,
                Comment = comment
            });

            // Optionally update phases (e.g., close Intake, open Investigation, etc.)
            UpdatePhases(complaint, newStatus, userId, comment);

            await _db.SaveChangesAsync();
        }

        private void UpdatePhases(Complaint complaint, ComplaintStatus newStatus, Guid userId, string? comment)
        {
            // Example: when moving to UnderReview, open Investigation phase
            if (newStatus == ComplaintStatus.UnderReview &&
                !complaint.ProcessingPhases.Any(p => p.PhaseType == ProcessingPhaseType.Investigation))
            {
                complaint.ProcessingPhases.Add(new ProcessingPhase
                {
                    Id = Guid.NewGuid(),
                    ComplaintId = complaint.Id,
                    PhaseType = ProcessingPhaseType.Investigation,
                    Status = ProcessingPhaseStatus.Open,
                    StartedAt = DateTime.UtcNow,
                    AssignedToUserId = complaint.AssignedToUserId,
                    Comments = comment
                });
            }

            if (newStatus == ComplaintStatus.Approved &&
                !complaint.ProcessingPhases.Any(p => p.PhaseType == ProcessingPhaseType.TribunalSubmission))
            {
                complaint.ProcessingPhases.Add(new ProcessingPhase
                {
                    Id = Guid.NewGuid(),
                    ComplaintId = complaint.Id,
                    PhaseType = ProcessingPhaseType.TribunalSubmission,
                    Status = ProcessingPhaseStatus.Open,
                    StartedAt = DateTime.UtcNow,
                    AssignedToUserId = userId,
                    Comments = "Ready for tribunal submission."
                });
            }
        }
    }
}

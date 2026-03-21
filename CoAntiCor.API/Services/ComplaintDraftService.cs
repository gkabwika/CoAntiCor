using CoAntiCor.Core.Domain;
using CoAntiCor.Core.Interfaces;
using CoAntiCor.Core.Model;
using CoAntiCor.Infrastructure.Context;
using Microsoft.AspNetCore.Hosting.Server;
using QRCoder;
using System.Drawing;
using System.Security.Cryptography;
using System.Text.Json;

namespace CoAntiCor.API.Services
{
    /// <summary>
    /// State management + draft saving for offline/disconnected scenarios
    /// You want:
    /// - Per‑step state in Blazor
    /// - Draft persisted in DB
    /// - Recovery if the network drops mid‑wizard
    /// 3.1. Wizard state model

    /// </summary>
    public class ComplaintDraftService : IComplaintDraftService
    {
        private readonly CoAntiCorDbContext _db;

        public ComplaintDraftService(CoAntiCorDbContext db) => _db = db;

        public async Task<Guid> SaveDraftAsync(ComplaintDraftState state, Guid? userId, bool isLinkclicked = false)
        {
            var entity = await _db.ComplaintDrafts.FindAsync(state.DraftId);

            var json = JsonSerializer.Serialize(state);

            if (entity is null)
            {
                entity = new ComplaintDraft
                {
                    Id = state.DraftId,
                    AccessCode = RandomNumberGenerator.GetInt32(100000, 999999).ToString(),
                    ReporterUserId = userId,
                    CurrentStep = state.CurrentStep,
                    StateJson = json,
                    LastUpdatedUtc = DateTime.UtcNow,
                    IsCompleted = false,
                    Version = state.Version++
                };
                 

                _db.ComplaintDrafts.Add(entity);
            }
            else
            {
                entity.CurrentStep = state.CurrentStep;
                entity.StateJson = json;
                entity.LastUpdatedUtc = DateTime.UtcNow;
            }
            entity.DeviceLinkToken = null;
            entity.DeviceLinkTokenExpiresUtc = null;
            if (isLinkclicked)
            {
                // Generate a short‑lived token for device linking. In a real app, you'd want to store this securely and associate it with the draft.
                var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32)); // generate a 32 bytes = 256 bits token
                entity.DeviceLinkToken = token;
                entity.DeviceLinkTokenExpiresUtc = DateTime.UtcNow.AddMinutes(10);
            }

            await _db.SaveChangesAsync();
            entity.ResumeUrl = $"/wizard?draftId={state.DraftId}"; //QR Code Resume Flow (Phone → Laptop → Tablet)
            return entity.Id;
        }

        // This is the V2 save method with conflict detection. The client should call this on every save,
        // and if a conflict is detected, it can prompt the user to either overwrite or merge changes.
        public async Task<DraftSaveResult> SaveDraftV2Async(ComplaintDraftState state, Guid? userId = default, bool isLinkClicked = false)
        {
            var current = await _db.ComplaintDrafts.FindAsync(state.DraftId);

            // Conflict detected
            if (current.Version != state.Version)
            {
                return new DraftSaveResult
                {
                    Success = false,
                    Conflict = true,
                    ServerStateJson = current.StateJson,
                    ServerVersion = current.Version
                };
            }

            // No conflict → update
            current.StateJson = JsonSerializer.Serialize(state);
            current.Version++;
            current.Id = state.DraftId;
            current.AccessCode = RandomNumberGenerator.GetInt32(100000, 999999).ToString();
            //current.ReporterUserId = userId;
            current.CurrentStep = state.CurrentStep;
            current.LastUpdatedUtc = DateTime.UtcNow;
            current.IsCompleted = false;

            current.DeviceLinkToken = null;
            current.DeviceLinkTokenExpiresUtc = null;
            if (isLinkClicked)
            {
                // Generate a short‑lived token for device linking. In a real app, you'd want to store this securely and associate it with the draft.
                var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32)); // generate a 32 bytes = 256 bits token
                current.DeviceLinkToken = token;
                current.DeviceLinkTokenExpiresUtc = DateTime.UtcNow.AddMinutes(10);
            }
            await _db.SaveChangesAsync();
            current.ResumeUrl = $"/wizard?draftId={state.DraftId}"; //QR Code Resume Flow (Phone → Laptop → Tablet)

            return new DraftSaveResult
            {
                Success = true,
                Conflict = false
            };
        }
        public async Task<ComplaintDraftState?> LoadDraftAsync(Guid draftId, Guid? userId)
        {
            var entity = await _db.ComplaintDrafts.FindAsync(draftId);
            if (entity is null) return null;

            if (entity.ReporterUserId.HasValue && userId.HasValue && entity.ReporterUserId != userId)
                return null; // security

            return JsonSerializer.Deserialize<ComplaintDraftState>(entity.StateJson);
        }

        //Generate QR code. Use a QR library like QRCoder(server-side) :
        public byte[] GenerateQrCode(string url)
        {
            using var generator = new QRCodeGenerator();
            var data = generator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            var qr = new PngByteQRCode(data);
            return qr.GetGraphic(20);
        }

    }
}

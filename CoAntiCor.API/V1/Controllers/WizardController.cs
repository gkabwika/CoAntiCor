using CoAntiCor.API.Services;
using CoAntiCor.Core.Domain.ServiceRequest;
using CoAntiCor.Core.DTO.Incident;
using CoAntiCor.Core.Enums;
using CoAntiCor.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoAntiCor.API.V1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WizardController : ControllerBase
    {
        private readonly CoAntiCorDbContext _db;

        public WizardController(CoAntiCorDbContext db)
        {
            _db = db;
        }

        // GET api/v1/wizard/{draftId}
        [HttpGet("{draftId:guid}")]
        public async Task<ActionResult<WizardDraftState>> GetDraft(Guid draftId)
        {
            var state = await _db.ServiceRequestWorkflowStates
                .FirstOrDefaultAsync(x => x.DraftId == draftId);

            if (state == null)
                return NotFound();

            return MapToDto(state);
        }

        // Autosave load
        [HttpGet("{draftId:guid}")]
        public async Task<ActionResult<WizardDraftState>> Get(Guid draftId)
        {
            var draft = await _db.IncidentRequests
                .Include(x => x.IncidentDetail)
                .Include(x => x.SecurityDetail)
                .FirstOrDefaultAsync(x => x.DraftId == draftId);

            if (draft == null)
                return NotFound();

            var state = IncidentWizardMapper.ToWizardDraftState(draft);
            return Ok(state);
        }

        // POST api/v1/wizard/save
        [HttpPost("save")]
        public async Task<ActionResult<SaveDraftResponse>> SaveDraft([FromBody] WizardDraftState dto)
        {
            var state = await _db.ServiceRequestWorkflowStates
                .FirstOrDefaultAsync(x => x.DraftId == dto.DraftId);

            // NEW DRAFT
            if (state == null)
            {
                state = new ServiceRequestWorkflowState
                {
                    Id = Guid.NewGuid(),
                    DraftId = dto.DraftId,
                    CurrentStep = dto.CurrentStep,
                    Code = $"DRAFT_{dto.DraftId}",
                    LabelFr = "Brouillon",
                    LabelEn = "Draft",
                    Version = 1,
                    LastSavedUtc = DateTime.UtcNow
                };

                ApplyDto(dto, state);

                _db.ServiceRequestWorkflowStates.Add(state);
                await _db.SaveChangesAsync();

                return new SaveDraftResponse
                {
                    Draft = MapToDto(state),
                    IsConflict = false
                };
            }

            // CONFLICT DETECTION
            if (dto.Version != state.Version)
            {
                return new SaveDraftResponse
                {
                    Draft = dto,
                    IsConflict = true,
                    ServerVersion = MapToDto(state)
                };
            }

            // MERGE + SAVE
            ApplyDto(dto, state);
            state.Version++;
            state.LastSavedUtc = DateTime.UtcNow;

            await _db.SaveChangesAsync();

            return new SaveDraftResponse
            {
                Draft = MapToDto(state),
                IsConflict = false
            };
        }
        // Autosave save
        [HttpPost("save")]
        public async Task<ActionResult> Save([FromBody] WizardDraftState state)
        {
            var existing = await _db.IncidentRequests
                .Include(x => x.IncidentDetail)
                .Include(x => x.SecurityDetail)
                .FirstOrDefaultAsync(x => x.DraftId == state.DraftId);

            if (existing == null)
            {
                var request = IncidentWizardMapper.ToIncidentRequest(state);
                _db.IncidentRequests.Add(request);
            }
            else
            {
                IncidentWizardMapper.UpdateIncidentRequest(existing, state);
            }

            await _db.SaveChangesAsync();
            return NoContent();
        }

        // Final submit
        [HttpPost("submit")]
        public async Task<ActionResult> Submit([FromBody] WizardDraftState state)
        {
            var existing = await _db.IncidentRequests
                .Include(x => x.IncidentDetail)
                .Include(x => x.SecurityDetail)
                .FirstOrDefaultAsync(x => x.DraftId == state.DraftId);

            if (existing == null)
            {
                var request = IncidentWizardMapper.ToIncidentRequest(state);
                request.Status = IncidentStatus.Submitted;
                _db.IncidentRequests.Add(request);
            }
            else
            {
                IncidentWizardMapper.UpdateIncidentRequest(existing, state);
                existing.Status = IncidentStatus.Submitted;
            }

            await _db.SaveChangesAsync();
            return Ok(new { state.DraftId });
        }
        // SUBMIT
        [HttpPost("submitold")]
        public async Task<ActionResult> SubmitOld([FromBody] WizardDraftState dto)
        {
            var state = await _db.ServiceRequestWorkflowStates
                .FirstOrDefaultAsync(x => x.DraftId == dto.DraftId);

            if (state == null)
                return BadRequest("Draft not found.");

            var incident = MapDraftToIncident(dto);

            _db.IncidentRequests.Add(incident);
            await _db.SaveChangesAsync();

            return Ok(new { incident.Id, incident.IncidentNumber });
        }

        // --------------------------
        // MAPPING FUNCTIONS
        // --------------------------

        private WizardDraftState MapToDto(ServiceRequestWorkflowState state)
        {
            return new WizardDraftState
            {
                DraftId = state.DraftId,
                CurrentStep = state.CurrentStep,
                Version = state.Version,

                SearchQuery = state.SearchQuery,
                AccessCode = state.AccessCode,

                IncidentTypeId = state.IncidentTypeId,
                IncidentCategoryId = state.IncidentCategoryId,
                IncidentTypeOther = state.IncidentTypeOther,
                CategoryOther = state.CategoryOther,

                IsAnonymous = state.IsAnonymous,
                CitizenName = state.ReporterName,
                CitizenEmail = state.ReporterEmail,
                CitizenPhone = state.ReporterPhone,
                Sex = state.Sex,
                AgeGroup = state.AgeGroup,
                AgeGroups = state.AgeGroups,
                Service = state.Service,
                JobRole = state.JobRole,
                ReporterFullName = state.ReporterFullName,

                Province = state.Province,
                City = state.City,
                Commune = state.Commune,
                Quartier = state.Quartier,
                Address = state.Address,
                GovernmentOfficeId = state.GovernmentOfficeId,

                Title = state.Title,
                Description = state.Description,

                IdentityChoice = state.IdentityChoice
            };
        }

        private void ApplyDto(WizardDraftState dto, ServiceRequestWorkflowState state)
        {
            state.CurrentStep = dto.CurrentStep;

            // Step 1
            state.SearchQuery = dto.SearchQuery;
            state.AccessCode = dto.AccessCode;

            // Step 2
            state.IncidentTypeId = dto.IncidentTypeId;
            state.IncidentCategoryId = dto.IncidentCategoryId;
            state.IncidentTypeOther = dto.IncidentTypeOther;
            state.CategoryOther = dto.CategoryOther;

            // Step 3
            state.IsAnonymous = dto.IsAnonymous;
            state.ReporterName = dto.CitizenName;
            state.ReporterEmail = dto.CitizenEmail;
            state.ReporterPhone = dto.CitizenPhone;
            state.Sex = dto.Sex;
            state.AgeGroup = dto.AgeGroup;
            state.AgeGroups = dto.AgeGroups;
            state.Service = dto.Service;
            state.JobRole = dto.JobRole;
            state.ReporterFullName = dto.ReporterFullName;

            // Step 4
            state.Province = dto.Province;
            state.City = dto.City;
            state.Commune = dto.Commune;
            state.Quartier = dto.Quartier;
            state.Address = dto.Address;
            state.GovernmentOfficeId = dto.GovernmentOfficeId;

            // Step 5
            state.Title = dto.Title;
            state.Description = dto.Description;

            // Step 6
            state.IdentityChoice = dto.IdentityChoice;
        }

        private IncidentRequest MapDraftToIncident(WizardDraftState dto)
        {
            return new IncidentRequest
            {
                Id = Guid.NewGuid(),
                IncidentNumber = GenerateIncidentNumber(),

                Title = dto.Title ?? "",
                Description = dto.Description ?? "",

                IncidentTypeId = dto.IncidentTypeId ?? Guid.Parse("10000000-0000-0000-0000-000000000023"),
                IncidentCategoryId = dto.IncidentCategoryId ?? Guid.Parse("20000000-0000-0000-0000-000000000008"),
                IncidentTypeOther = dto.IncidentTypeOther ?? "",
                Category = dto.CategoryOther ?? "",

                Province = dto.Province ?? "",
                City = dto.City ?? "",
                Commune = dto.Commune ?? "",
                Quartier = dto.Quartier ?? "",
                Address = dto.Address ?? "",

                IsAnonymous = dto.IsAnonymous,
                CitizenName = dto.IsAnonymous ? null : dto.CitizenName,
                CitizenEmail = dto.IsAnonymous ? null : dto.CitizenEmail,
                CitizenPhone = dto.IsAnonymous ? null : dto.CitizenPhone,
                Sex = dto.Sex,
                AgeGroup = dto.AgeGroup,
                AgeGroups = dto.AgeGroups,
                Service = dto.Service,
                JobRole = dto.JobRole,
                ReporterFullName = dto.ReporterFullName,

                GovernmentOfficeId = dto.GovernmentOfficeId ?? Guid.Parse("70000000-0000-0000-0000-000000000001"),

                Status = IncidentStatus.Submitted,
                CreatedAt = DateTime.UtcNow,
                SubmittedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            };
        }

        private string GenerateIncidentNumber()
        {
            var datePart = DateTime.UtcNow.ToString("yyyyMMdd");
            var randomPart = Guid.NewGuid().ToString("N")[..6].ToUpperInvariant();
            return $"COA-{datePart}-{randomPart}";
        }
    }


}

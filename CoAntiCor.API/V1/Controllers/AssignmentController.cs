using CoAntiCor.API.Services;
using CoAntiCor.Core.Interfaces;
using CoAntiCor.Core.Model;
using CoAntiCor.Core.Services;
using CoAntiCor.Infrastructure.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoAntiCor.API.V1.Controllers
{
    [Authorize(Policy = "CanAssignCases")]
    [Route("api/[controller]")]
    [ApiController] 
    public class AssignmentController : ControllerBase
    {
        private readonly CoAntiCorDbContext _db;
        private readonly IComplaintNumberGenerator _numberGenerator;
        private readonly IAttachmentService _attachmentService;
        private readonly INotificationService _notificationService;

        public AssignmentController(
            CoAntiCorDbContext db,
            IComplaintNumberGenerator numberGenerator,
            IAttachmentService attachmentService,
            INotificationService notificationService)
        {
            _db = db;
            _numberGenerator = numberGenerator;
            _attachmentService = attachmentService;
            _notificationService = notificationService;
        }

        [Authorize(Policy = "CanViewAllComplaints")]
        [HttpPost("{id:guid}/status")]
        public async Task<IActionResult> ChangeStatus(Guid id, [FromBody] ChangeStatusRequest request,
            [FromServices] IProcessingPhaseEngine engine)
        {
            var userId = Guid.Parse(User.FindFirst("sub")!.Value);
            await engine.ChangeStatusAsync(id, request.NewStatus, userId, request.Comment);
            return NoContent();
        }


    }
}

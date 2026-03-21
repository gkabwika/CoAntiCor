using CoAntiCor.Core.Interfaces;
using CoAntiCor.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;

        public NotificationService(IEmailSender emailSender, ISmsSender smsSender)
        {
            _emailSender = emailSender;
            _smsSender = smsSender;
        }

        public async Task SendComplaintConfirmationAsync(string? email, string? phone, string complaintNumber)
        {
            var message = $"Your complaint {complaintNumber} has been received. You will be contacted within 24 hours.";

            if (!string.IsNullOrWhiteSpace(email))
                await _emailSender.SendAsync(email, "Complaint received", message);

            if (!string.IsNullOrWhiteSpace(phone))
                await _smsSender.SendAsync(phone, message);
        }

        public async Task SendStatusChangeAsync(string? email, string? phone, string complaintNumber, ComplaintStatus newStatus)
        {
            var message = $"The status of your complaint {complaintNumber} is now: {newStatus}.";

            if (!string.IsNullOrWhiteSpace(email))
                await _emailSender.SendAsync(email, "Complaint status updated", message);

            if (!string.IsNullOrWhiteSpace(phone))
                await _smsSender.SendAsync(phone, message);
        }
    }
}

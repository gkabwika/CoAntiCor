using CoAntiCor.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Interfaces
{
    public interface INotificationService
    {
        Task SendComplaintConfirmationAsync(string? email, string? phone, string complaintNumber);
        Task SendStatusChangeAsync(string? email, string? phone, string complaintNumber, ComplaintStatus newStatus);
    }
}

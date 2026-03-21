//using namespace CoAntiCor.Core.Notifications;
namespace CoAntiCor.Core.Interfaces
{
    public interface IEmailSender
    {
        Task SendAsync(string to, string subject, string body);
        Task SendAsync(object email, string v1, string v2);
    }
}

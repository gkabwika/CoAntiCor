//using namespace CoAntiCor.Core.Notifications;

namespace CoAntiCor.Core.Interfaces
{
    public interface ISmsSender
    {
        Task SendAsync(string phoneNumber, string message);
    }
}

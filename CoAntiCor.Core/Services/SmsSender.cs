using CoAntiCor.Core.Interfaces;
//using CoAntiCor.Core.Notifications;

namespace CoAntiCor.Core.Services;

public class SmsSender : ISmsSender
{
    public Task SendAsync(string phoneNumber, string message)
    {
        // TODO: integrate with real SMS gateway (e.g., Twilio, local provider)
        Console.WriteLine($"SMS to {phoneNumber}: {message}");
        return Task.CompletedTask;
    }
}


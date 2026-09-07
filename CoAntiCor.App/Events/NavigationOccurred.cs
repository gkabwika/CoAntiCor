using MediatR;

namespace CoAntiCor.App.Events
{
    public record NavigationOccurred(string Path, string? UserId) : INotification;

}

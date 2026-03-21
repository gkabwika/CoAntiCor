using MediatR;

namespace CoAntiCor.Events
{
    public record NavigationOccurred(string Path, string? UserId) : INotification;

}

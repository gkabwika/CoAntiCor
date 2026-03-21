using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using System.Security.Claims;
using CoAntiCor.Events;

namespace CoAntiCor.Services
{
    /// <summary>
    /// Blazor navigation hook
    /// </summary>
    public class AuditedNavigationManager 
    {
        private readonly NavigationManager _nav;
        private readonly IMediator _mediator;
        private readonly AuthenticationStateProvider _auth;

        public AuditedNavigationManager(
            NavigationManager nav,
            IMediator mediator,
            AuthenticationStateProvider auth)
        {
            _nav = nav;
            _mediator = mediator;
            _auth = auth;

            // Subscribe to event
            _nav.LocationChanged += OnLocationChanged;
        }

        private async void OnLocationChanged(object? sender, LocationChangedEventArgs e)
        {
            var state = await _auth.GetAuthenticationStateAsync();
            var userId = state.User.Identity?.IsAuthenticated == true
                ? state.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                : null;

            await _mediator.Publish(new NavigationOccurred(e.Location, userId));
        }

        //public void Dispose()
        //{
        //    // Unsubscribe to avoid memory leaks
        //    _nav.LocationChanged -= OnLocationChanged;
        //}
    }


}

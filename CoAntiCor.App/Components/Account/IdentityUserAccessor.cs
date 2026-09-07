using CoAntiCor.App.Data;
using Microsoft.AspNetCore.Identity;

namespace CoAntiCor.App.Components.Account
{
    internal sealed class IdentityUserAccessor(UserManager<CoAntiCor.Core.Domain.ApplicationUser> userManager, IdentityRedirectManager redirectManager)
    {
        public async Task<CoAntiCor.Core.Domain.ApplicationUser> GetRequiredUserAsync(HttpContext context)
        {
            var user = await userManager.GetUserAsync(context.User);

            if (user is null)
            {
                redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
            }

            return user;
        }
    }
}

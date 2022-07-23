using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace RazorClassLibrary1
{
    public partial class SecuredPage
    {
        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        private ClaimsPrincipal User { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authenticationState =
                 await this.AuthenticationStateProvider.GetAuthenticationStateAsync();

            var principal =
                authenticationState.User;

            if (principal.Identity != null && principal.Identity.IsAuthenticated)
            {
                this.User =
                    authenticationState.User;
            }
        }
    }
}

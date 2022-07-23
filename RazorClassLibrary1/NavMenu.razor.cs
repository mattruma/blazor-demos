using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace RazorClassLibrary1
{
    public partial class NavMenu : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public SignOutSessionStateManager SignOutManager { get; set; }

        protected async Task SignOut()
        {
            await SignOutManager.SetSignOutState();

            this.NavigationManager.NavigateTo("authentication/logout");
        }
    }
}

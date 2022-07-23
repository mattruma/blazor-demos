using Microsoft.AspNetCore.Components;

namespace RazorClassLibrary1
{
    public partial class RedirectToLoginComponent : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            this.NavigationManager.NavigateTo($"authentication/login?returnUrl={Uri.EscapeDataString(this.NavigationManager.Uri)}");
        }
    }
}

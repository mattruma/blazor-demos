namespace RazorClassLibrary1
{
    public partial class AuthenticationPage
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string? Action { get; set; }

        protected override void OnInitialized()
        {
            if (this.Action == "logged-out") this.NavigationManager.NavigateTo("/");
        }
    }
}

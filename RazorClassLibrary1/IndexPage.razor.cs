using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;

namespace RazorClassLibrary1
{
    public partial class IndexPage
    {
        [Inject]
        public IConfiguration Configuration { get; set; }

        [Inject]
        public ExampleJsInterop ExampleJsInterop { get; set; }

        private async Task Prompt()
        {
            var message = await this.ExampleJsInterop.Prompt("Enter some text:");

            await this.ExampleJsInterop.Alert(message);
        }
    }
}

using Blazorise;

namespace BlazorApp1
{
    public partial class App
    {
        public Theme DefaultTheme = new()
        {
            BackgroundOptions = new ThemeBackgroundOptions
            {
                Danger = "#FF2E2E",
                Light = "#EFF3F9",
                Primary = "#3B82F6",
                Success = "#44AF69"
            },
            BodyOptions = new ThemeBodyOptions
            {
                BackgroundColor = "#FFFFFF",
                TextColor = "#444444"
            },
            ColorOptions = new ThemeColorOptions
            {
                Danger = "#FF2E2E",
                Link = "#3B82F6",
                Primary = "#3B82F6",
                Success = "#44AF69"
            },
            TextColorOptions = new ThemeTextColorOptions
            {
                Danger = "#FF2E2E",
                Primary = "#3B82F6",
                Success = "#44AF69",
                Muted = "#94A3B8"
            }
        };
    }
}

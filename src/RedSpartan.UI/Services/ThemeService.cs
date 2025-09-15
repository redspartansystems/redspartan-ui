using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace RedSpartan.UI.Services
{
    public interface IThemeService
    {
        string CurrentTheme { get; }
        event Action<string>? ThemeChanged;
        Task SetThemeAsync(string theme);
        Task<string> GetThemeAsync();
    }

    public class ThemeService : IThemeService
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly ILogger<ThemeService> _logger;
        private string _currentTheme = "light";

        public string CurrentTheme => _currentTheme;
        public event Action<string>? ThemeChanged;

        public ThemeService(IJSRuntime jsRuntime, ILogger<ThemeService> logger)
        {
            _jsRuntime = jsRuntime;
            _logger = logger;
        }

        public async Task SetThemeAsync(string theme)
        {
            try
            {
                _currentTheme = theme;
                await _jsRuntime.InvokeVoidAsync("RedSpartanUI.setTheme", theme);
                ThemeChanged?.Invoke(theme);
                _logger.LogDebug("Theme changed to: {Theme}", theme);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to set theme to: {Theme}", theme);
            }
        }

        public async Task<string> GetThemeAsync()
        {
            try
            {
                var theme = await _jsRuntime.InvokeAsync<string>("RedSpartanUI.getTheme");
                _currentTheme = theme ?? "light";
                return _currentTheme;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get current theme, defaulting to light");
                return "light";
            }
        }
    }
}

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RedSpartan.UI.Services;

namespace RedSpartan.UI.Components
{
    public abstract class RedSpartanComponentBase : ComponentBase, IDisposable
    {
        protected string ComponentId { get; } = $"rs-{Guid.NewGuid():N}";
        protected bool IsDarkTheme => ThemeService?.CurrentTheme == "dark";
        
        [Inject] protected IThemeService? ThemeService { get; set; }
        [Inject] protected IJSRuntime JSRuntime { get; set; } = null!;
        
        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (ThemeService != null)
            {
                ThemeService.ThemeChanged += OnThemeChanged;
            }
        }
        
        private async void OnThemeChanged(string newTheme)
        {
            await InvokeAsync(StateHasChanged);
        }
        
        public virtual void Dispose()
        {
            if (ThemeService != null)
            {
                ThemeService.ThemeChanged -= OnThemeChanged;
            }
        }
    }
}

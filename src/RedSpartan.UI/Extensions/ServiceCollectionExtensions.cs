using Microsoft.Extensions.DependencyInjection;
using RedSpartan.UI.Services;

namespace RedSpartan.UI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRedSpartanUI(this IServiceCollection services)
        {
            services.AddScoped<IThemeService, ThemeService>();
            return services;
        }
    }
}

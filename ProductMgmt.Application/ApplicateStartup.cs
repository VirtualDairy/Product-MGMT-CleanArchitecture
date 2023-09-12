using Microsoft.Extensions.DependencyInjection;

namespace ProductMgmt.Application
{
    public static class ApplicationStartup
    {
        public static void UseApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductAppService, ProductAppService>();
        }
    }
}

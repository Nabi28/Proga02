using Entities;
using Microsoft.Extensions.DependencyInjection;

namespace DATA
{
    public static class DependencyContainer
    {
        public static void AddDATA(this IServiceCollection services)
        {
            services.AddScoped<RestauranteDbContext>();
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;

namespace Services
{
    public static class DependencyContairner
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICliente, ClienteServicios>();
            services.AddScoped<Ibloqueo, BloqueoServicios>();
        }
    }
}

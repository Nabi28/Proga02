using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;

namespace Services
{
    public static class DependencyContairner
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICliente, ClienteServicios>();
            services.AddScoped<IBloqueo, BloqueoServicios>();
            services.AddScoped<ISeccion, SeccionServicios>();
            services.AddScoped<IZona, ZonaServicios>();
            services.AddScoped<IReserva, ReservaServicios>();
            services.AddScoped<IMesa, MesaServicios>();
        }
    }
}

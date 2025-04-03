using Application.Interfaces.Entidades.AreaTrabajoInterfaces;
using Application.Services.Entidades;
using Infraestructure.Repositorio.Entidades;
using Microsoft.Extensions.DependencyInjection;
namespace Infraestructure
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            //los services.AddScoped de AreaTrabajo
            services.AddScoped<IAreaTrabajoRepository, AreaTrabajoRepository>();
            services.AddScoped<IAreaTrabajoService, AreaTrabajoService>();

            //Aquí agregar las otras entidades y agregados

            // Registrar JwtService como Singleton
            services.AddSingleton<JwtService>();

            return services;
        }
    }
}

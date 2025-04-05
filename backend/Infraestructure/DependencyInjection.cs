using Application.Interfaces.Entidades.AreaTrabajoInterfaces;
using Application.Interfaces.Entidades.CiudadInterfaces;
using Application.Interfaces.Entidades.DepartamentoInterfaces;
using Application.Interfaces.Entidades.DireccionInterfaces;
using Application.Interfaces.Entidades.PaisInterfaces;
using Application.Interfaces.Entidades.PersonaInterfaces;
using Application.Interfaces.Entidades.PuestoTrabajoInterfaces;
using Application.Interfaces.Entidades.RolInterfaces;
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
            services.AddScoped<IPaisRepository, PaisRepository>();
            services.AddScoped<IPaisService, PaisService>();

            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            services.AddScoped<IDepartamentoService, DepartamentoService>();

            services.AddScoped<ICiudadRepository, CiudadRepository>();
            services.AddScoped<ICiudadService, CiudadService>();

            services.AddScoped<IDireccionRepository, DireccionRepository>();
            services.AddScoped<IDireccionService, DireccionService>();

            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IPersonaService, PersonaService>();

            services.AddScoped<IRolRepository, RolRepository>();
            services.AddScoped<IRolService, RolService>();

            services.AddScoped<IPuestoTrabajoRepository, PuestoTrabajoRepository>();
            services.AddScoped<IPuestoTrabajoService, PuestoTrabajoService>();

            // Registrar JwtService como Singleton
            services.AddSingleton<JwtService>();

            return services;
        }
    }
}

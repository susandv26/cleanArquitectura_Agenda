using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Dominio.Entities;
using Infraestructure.Repositorio;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces.Entidades;
using Application.Services.Entidades;
using Infraestructure.Repositorio.Entidades;

namespace Infraestructure
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
           
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            return services;
        }
    }
}

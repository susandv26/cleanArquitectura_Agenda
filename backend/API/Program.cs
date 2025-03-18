
using API.Configuration;
using Application.Services.Entidades;
using Infraestructure.Persistence;
using Infraestructure.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Entidades;
using Application.Interfaces.Actividades;
using Infraestructure.Repositorio.Actividades;
using Application.Services.Actividades;


namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);






            // Add services to the container.
            builder.Services.AddAuthorization();


            //liena nueva 1
            var dbConfig = new DatabaseConfig();

            //liena extra 2
            builder.Services.AddDbContext<BackendDBContext>(options => options.UseSqlServer(dbConfig.ConnectionString));

            //liena extra 3
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            //liena extra 3.2
            builder.Services.AddScoped<ITipoRepository, TipoRepository>();
            builder.Services.AddScoped<ITipoService, TipoService>();

           // builder.Services.AddScoped<ITipoRepository, TipoRepository>();
           // builder.Services.AddScoped<ITipoService, TipoService>();

           // builder.Services.AddScoped<ITareaRepository, TareaRepository>();
           // builder.Services.AddScoped<ITareaService, TareaService>();

            builder.Services.AddScoped<IActividadRepository, ActividadRepository>();
            builder.Services.AddScoped<IActividadService, ActividadService>();

            





            //liena extra 4
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            app.MapGet("/weatherforecast", (HttpContext httpContext) =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();

            app.Run();
        }
    }
}

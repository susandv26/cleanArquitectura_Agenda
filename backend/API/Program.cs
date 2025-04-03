
using API.Configuration;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Infraestructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Infrastructure;



namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configurar autenticación JWT
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };
                });


            // Add services to the container.
            builder.Services.AddAuthorization();


            //liena nueva 1
            var dbConfig = new DatabaseConfig();

            //liena extra 2
            builder.Services.AddDbContext<BackendDBContext>(options => options.UseSqlServer(dbConfig.ConnectionString));

            //liena extra 3
            
            //liena extra 3.2

           builder.Services.AddInfrastructure();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            //ya estaba, solo se modifica dentro de los parentesis
            builder.Services.AddSwaggerGen(options =>
            {
                // Agregar definición de seguridad
                // se corrige Type = SecuritySchemeType.ApiKey por Type = SecuritySchemeType.Http
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http, //el Http 
                    Scheme = "Bearer",  // Esto es importante para JWT
                    BearerFormat = "JWT", // Formato de JWT
                    In = ParameterLocation.Header,
                    Description = "Por favor ingresa tu token JWT"
                });

                // Agregar requisitos de seguridad global
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer" // Este nombre debe coincidir con el de la definición
                            }
                        },
                        new string[] { }
                    }
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication(); // línea correspondiente al JWT

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}

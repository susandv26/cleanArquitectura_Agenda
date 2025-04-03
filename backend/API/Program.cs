
using API.Configuration;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Infraestructure;



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
            
            //liena extra 3.2

           builder.Services.AddInfrastructure();

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

            app.MapControllers();

            app.Run();

        }
    }
}

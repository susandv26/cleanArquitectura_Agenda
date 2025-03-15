﻿
using DotNetEnv;
using Microsoft.Extensions.Configuration;


namespace API.Configuration
{
    public class DatabaseConfig
    {
        public string ConnectionString { get; }

        public DatabaseConfig()
        {
            DotNetEnv.Env.Load();

            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            string dbServer = configuration["DB_SERVER"] ?? "localhost";
            string dbPort = configuration["DB_PORT"] ?? "1433";
            string dbName = configuration["DB_NAME"] ?? "Bd_Agenda";
            string dbUser= configuration["DB_USER"] ?? "sa";
            string dbPassword = configuration["DB_PASSWORD"] ?? "123";

            ConnectionString = $"Server={dbServer},{dbPort}; Database = {dbName};User Id ={dbUser};Password = {dbPassword}; TrustServerCertificate=True";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using MassTransit;

namespace LogManager.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            try
            {
                Log.Information("LoggerAPI is Starting at {0}",System.DateTime.Now);
                CreateHostBuilder(args).Build().Run();
                return ;
            }
            catch (Exception a)
            {
                Log.Error("LoggerAPI catch a error at {0} =>{1}", System.DateTime.Now, a.Message);
            }
            finally
            {
                Log.Information("LoggerAPI is Stop at {0}", System.DateTime.Now);
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog();
    }
}

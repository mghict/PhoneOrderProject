using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogManager.Api.InternalLog;
using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LogManager.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //services.AddMassTransit(x =>
            //{
            //    x.UsingRabbitMq();
            //});
            //services.AddTransient<BehsamFramework.Entity.LogFromat>();

            /*services.AddMassTransit(x =>
            {
                x.AddConsumer<EventConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("rabbitmq://localhost", h =>
                    {
                        h.Username("admin");
                        h.Password("admin");
                    });

                    cfg.ReceiveEndpoint("event-log-listener", e =>
                    {
                        e.ConfigureConsumer<EventConsumer>(context);
                    });

                    cfg.AutoStart = true;
                });

                
            });

            services.AddMassTransitHostedService();*/

            services.AddHostedService<LogConsumer>();
            services.AddHostedService<InternalLoggerService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gateway.PanelAPI.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;
using Ocelot;
using Ocelot.Provider.Polly;
using Microsoft.AspNetCore.ResponseCompression;
using System.Net.Mime;

namespace Gateway.PanelAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfigurationRoot Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsetting.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsetting.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile("ocelot.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ITokenSecurity,TokenSecurity>();


            services.AddOcelot(Configuration)
                .AddPolly()
                //.AddTransientDefinedAggregator< Aggregator>()
                .AddCacheManager(x =>
                {
                    x.WithDictionaryHandle();
                });


            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                builder.AllowAnyOrigin() //WithOrigins("https://localhost:44338")
                       .AllowAnyMethod()
                       .AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseMiddleware<Middleware.JwtMiddleware>();
            app.UseCors();

            app.UseOcelot().Wait();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

        }
    }
}

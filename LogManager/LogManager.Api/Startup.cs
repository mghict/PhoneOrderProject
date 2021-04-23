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
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new BehsamFramework.Utility.TimeSpanToStringConverter());
                });

			//services.AddHostedService<LogConsumer>();
			// **************************************************
			services.AddTransient<Persistence.IUnitOfWork, Persistence.UnitOfWork>(current =>
			{
				string databaseConnectionString =
					Configuration
					.GetSection(key: "ConnectionStrings")
					.GetSection(key: "CommandsConnectionString")
					.Value;

				string databaseProviderString =
					Configuration
					.GetSection(key: "CommandsDatabaseProvider")
					.Value;

				BehsamFramework.DapperDomain.Enums.Provider databaseProvider =
					(BehsamFramework.DapperDomain.Enums.Provider)
					System.Convert.ToInt32(databaseProviderString);

				BehsamFramework.DapperDomain.Options options =
					new BehsamFramework.DapperDomain.Options
					{
						Provider = databaseProvider,
						ConnectionString = databaseConnectionString,
					};

				return new Persistence.UnitOfWork(options: options);
			});
			// **************************************************
			// **************************************************
			services.AddTransient<Persistence.IQueryUnitOfWork, Persistence.QueryUnitOfWork>(current =>
			{
				string databaseConnectionString =
					Configuration
					.GetSection(key: "ConnectionStrings")
					.GetSection(key: "QueriesConnectionString")
					.Value;

				string databaseProviderString =
					Configuration
					.GetSection(key: "QueriesDatabaseProvider")
					.Value;

				BehsamFramework.DapperDomain.Enums.Provider databaseProvider =
					(BehsamFramework.DapperDomain.Enums.Provider)
					System.Convert.ToInt32(databaseProviderString);

				BehsamFramework.DapperDomain.Options options =
					new BehsamFramework.DapperDomain.Options
					{
						Provider = databaseProvider,
						ConnectionString = databaseConnectionString,
					};

				return new Persistence.QueryUnitOfWork(options: options);
			});
			// **************************************************

			services.AddHostedService<InternalLoggerService>();
			services.AddHostedService<DataLog.DataLogService>();
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

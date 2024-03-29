using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UserManagement;

namespace UserManagement.API
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
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new BehsamFramework.Utility.TimeSpanToStringConverter());
            });

            services.AddSingleton<BehsamFramework.Util.Security.ISecurePasswordHasherHelper, BehsamFramework.Util.Security.SecurePasswordHasherHelper>(current=> {
                string _Iterate =
                    Configuration
                    .GetSection(key: "Iterate")
                    .Value;

                string _PassFormat =
                    Configuration
                    .GetSection(key: "PassFormat")
                    .Value;
                return new BehsamFramework.Util.Security.SecurePasswordHasherHelper(_PassFormat, Convert.ToInt32( _Iterate));


            });

            services.ConfigureServices
                (configuration: Configuration); 
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

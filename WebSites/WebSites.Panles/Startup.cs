using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebSites.Panles.Helper;

namespace WebSites.Panles
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
            //services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddMvc().AddNewtonsoftJson().AddJsonOptions(options=>
            {
                options.JsonSerializerOptions.Converters.Add(new BehsamFramework.Utility.TimeSpanToStringConverter());
            });
            services.AddMvcCore().AddNewtonsoftJson().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new BehsamFramework.Utility.TimeSpanToStringConverter());
            });
            services.AddControllersWithViews();
            services.AddRazorPages();

            //Class BuiltIn Dependency

            services.AddHttpClient();
            services.AddHttpClient("ApiGateway",c=>
            {
                c.BaseAddress =new Uri(Configuration.GetValue<string>("ApiGatewayURL"));
            });
            services.AddMemoryCache();

            services.AddScoped<ICacheService, InMemoryCache>();
            services.AddScoped<StaticValues>();
            services.AddAutoMapper(typeof(Mapper.BaseMapper).GetTypeInfo().Assembly);

            //Class Dependency
            
            services.AddScoped<WebSites.Panles.Helper.ServiceCaller>();
            services.AddScoped<Services.Customer.IGetCustomer, Services.Customer.GetCustomer>();
            services.AddScoped<Services.CustomerPhone.IGetCustomerPhone, Services.CustomerPhone.GetCustomerPhone>();
            services.AddScoped<Services.CustomerPhone.IGetPhoneByIdService, Services.CustomerPhone.GetPhoneByIdService>();
            services.AddScoped<Services.CustomerAddress.IGetAddressByIdService, Services.CustomerAddress.GetAddressByIdService>();
            services.AddScoped<Services.CustomerAddress.IGetCustomerAddressService, Services.CustomerAddress.GetCustomerAddressService>();
            services.AddScoped<Services.Customer.IGetCustomerBySearch, Services.Customer.GetCustomerBySearch>();

            //Facad Services
            services.AddScoped<Services.IOrderFacad, Services.OrderFacad>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}");

                endpoints.MapAreaControllerRoute(
                    name: "CallCenter",
                    areaName: "CallCenter",
                    pattern: "CallCenter/{controller=Login}/{action=Login}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");



                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });

            
        }
    }
}

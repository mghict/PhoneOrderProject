using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace WebSite.JourChin
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
            services.AddControllersWithViews().AddNewtonsoftJson().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new BehsamFramework.Utility.TimeSpanToStringConverter());
            });

            services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new BehsamFramework.Utility.TimeSpanToStringConverter());
            });

            services.AddRazorPages();

            //Attribute For Authorize
            services.TryAddEnumerable(ServiceDescriptor.Transient<IApplicationModelProvider, Helper.MyApplicationProvider>());

            //SignalR
            services.AddSignalR();

            //PWA
            services.AddProgressiveWebApp();

            //AutoMapper
            services.AddAutoMapper(typeof(Mapper.BaseMapper).GetTypeInfo().Assembly);

            //Class BuiltIn Dependency For Sesson and HttpContext
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(2);
                options.Cookie.HttpOnly = true;

            });
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //MemoryCachedServices
            services.AddMemoryCache();
            services.AddSingleton<Helper.ICachedMemoryService, Helper.CachedMemoryService>();

            //ServiceCaller
            services.AddHttpClient();
            services.AddHttpClient("ApiGateway", c =>
            {
                c.BaseAddress = new Uri(Configuration.GetValue<string>("ApiGatewayURL"));
            });
            services.AddTransient<WebSite.JourChin.Helper.ServiceCaller>();

            //AuthorizeService
            services.AddTransient<Services.Authorize.IAuthorizeService, Services.Authorize.AuthorizeService>();

            //Services Inject
            services.AddScoped<Services.User.IUserActivityService, Services.User.UserActivityService>();
            services.AddScoped<Services.Order.IOrderService, Services.Order.OrderService>();
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
            }

            //For Error Pages And Redirect to Custome Page
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 401)
                {
                    context.Request.Path = "/Home/Index";
                    await next();
                }
            });

            //Session Enable
            app.UseSession();

            //Https
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=login}/{id?}");

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();

            });
        }
    }
}

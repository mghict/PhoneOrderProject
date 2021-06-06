using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebSite.Safir.Helper;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Components.Authorization;
using WebSite.Safir.Services;
using Microsoft.Extensions.Http;
using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace WebSite.Safir
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            
            builder.RootComponents.Add<App>("app");

            builder.Services.AddSingleton<Settings>();




            builder.Services.AddScoped(_ => new DefaultBrowserOptionsMessageHandler
            {
                DefaultBrowserRequestCache = BrowserRequestCache.NoStore,
                DefaultBrowserRequestMode=BrowserRequestMode.SameOrigin
            });

            builder.Services.AddHttpClient("Default", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<DefaultBrowserOptionsMessageHandler>();

            builder.Services.AddScoped<HttpClient>(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Default"));




            builder.Services.AddScoped<UserLoginData>();
            builder.Services.AddScoped<ServiceCaller>();
            builder.Services.AddScoped<IAlertService, AlertService>();



            builder.Services.AddScoped<IAccountService, AccountService>();

            var host = builder.Build();

            var accountService = host.Services.GetRequiredService<IAccountService>();
            await accountService.Initialize();

            await host.RunAsync();

        }


    }
}

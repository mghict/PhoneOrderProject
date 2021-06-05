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

namespace WebSite.Safir
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            //builder.Services.AddSingleton(async p =>
            //{
            //    var httpClient = p.GetRequiredService<HttpClient>();
            //    var sett= await httpClient.GetJsonAsync<Settings>("appsettings.json")
            //        .ConfigureAwait(false);

            //    return sett;
            //});

            builder.Services.AddSingleton<Settings>();

            builder.Services.AddScoped(p => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<ServiceCaller>();

            builder.RootComponents.Add<App>("app");


            //builder.Services.AddTransient(sp =>
            // var client=new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }

            // return client;
            //);
            

            await builder.Build().RunAsync();
        }

       
    }
}

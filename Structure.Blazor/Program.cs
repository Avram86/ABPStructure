using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Structure.Blazor.Services.LabelObject;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services
                .AddBlazorise(options =>
                    {
                     options.ChangeTextOnKeyPress = true;
                    })
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();

            builder.Services.AddOidcAuthentication(options =>
            {
                //added in the wwwroot/appsettings.json file
                ////address of ID4
                //options.ProviderOptions.Authority = "https://localhost:5001";
                //options.ProviderOptions.ClientId = "structure";

                ////address of client=blazor 
                //options.ProviderOptions.RedirectUri = "https://localhost:44354/authentication/login-callback";
                //options.ProviderOptions.PostLogoutRedirectUri = "https://localhost:44354/authentication/signout-callback";

                //options.ProviderOptions.DefaultScopes.Add("email");
                //options.ProviderOptions.DefaultScopes.Add("structureapi");
               
                //options.ProviderOptions.ResponseType = "code";
                ////default behaviour: necessary steps to support PKCE
                ///

                //bind the key-value pairs in appsettings to the provider
                builder.Configuration.Bind("OidcConfiguration", options.ProviderOptions);
                
            });


            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44345/") });

            //registering the HttpClientFactory
            builder.Services.AddHttpClient<ILabelObjectServices, LabelObjectServices>(client => client.BaseAddress = new Uri("https://localhost:44345/"));


            //adding the ProfileMappingFile to the configuration of AutoMapper
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Structure.Blazor.AutoMapperProfile());
            });
            var mapper = config.CreateMapper();
            builder.Services.AddSingleton(mapper);


            //adding the rest of the services
            builder.Services.AddScoped<ILabelObjectServices, LabelObjectServices>();
            builder.Services.AddLocalization(options=>options.ResourcesPath="StructureResource");
            

            await builder.Build().RunAsync();
        }

     
    }
}

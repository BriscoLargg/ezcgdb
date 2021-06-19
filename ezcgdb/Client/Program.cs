using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FluentValidation;
using ezcgdb.Shared;
using ezcgdb.Shared.Services;
using MudBlazor.Services;

namespace ezcgdb.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            ConfigureCommonServices(builder.Services);

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddSingleton<IAuthService, WasmAuthService>();

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();

            builder.Services.AddSingleton<IAuthorizationPolicyProvider, DefaultAuthorizationPolicyProvider>();
            builder.Services.AddSingleton<IAuthorizationService, DefaultAuthorizationService>();

            builder.Services.AddMudServices();

            var host = builder.Build();
            await host.RunAsync();
        }

        public static void ConfigureCommonServices(IServiceCollection services)
        {
            services.AddTransient<GrpcClientInterceptor>();

            services.AddGrpcClient<IWeatherForecastService>();
            services.AddGrpcClient<ICounterService>();

            services.AddValidatorsFromAssemblyContaining<ezcgdb.Shared.LoginRequest>();

            services.AddScoped<HostAuthenticationStateProvider>();
            services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<HostAuthenticationStateProvider>());
        }
    }
}

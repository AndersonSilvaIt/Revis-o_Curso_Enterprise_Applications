using Microsoft.Extensions.DependencyInjection;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Services;
using NSE.WebApp.MVC.Services.Handlers;
using Polly;
using Polly.Extensions.Http;
using System;

namespace NSE.WebApp.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();

            var retryWaitPoolice = HttpPolicyExtensions
                                   .HandleTransientHttpError()
                                   .WaitAndRetryAsync(new[]
                                   {
                                       TimeSpan.FromSeconds(1), // Após o primeiro erro, esperar 1 segundo
                                       TimeSpan.FromSeconds(5), // Após. esperar 5 segundos ...
                                       TimeSpan.FromSeconds(10)
                                   },
                                    (outcome, timespan, retrycount, context) =>
                                   {
                                       Console.ForegroundColor = ConsoleColor.Blue;
                                       Console.WriteLine($"Tentando pela { retrycount} vez! ");
                                       Console.ForegroundColor = ConsoleColor.White;
                                   });


            services.AddHttpClient<ICatalogoService, CatalogoService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                //.AddTransientHttpErrorPolicy(
                //p => p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(600))); //O Polly irá tentar executar por 3 vezes, até estourar uma exceção
                .AddPolicyHandler(retryWaitPoolice);
            //services.AddHttpClient("Refit", options =>
            //{
            //    options.BaseAddress = new Uri(configuration.GetSection("CatalogoUrl").Value);
            //})
            //    .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            //    .AddTypedClient(Refit.RestService.For<ICatalogoServiceRefit>);
            // Caso opte por usar o Refir para consumo Rest, basta descomentar o código acima.

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}

﻿using NSE.Pagamentos.API.Data.Repository;
using NSE.Pagamentos.API.Data;
using NSE.Pagamentos.API.Models;
using NSE.WebAPI.Core.Usuario;
using NSE.Pagamentos.API.Services;
using NSE.Pagamentos.API.Facade;

namespace NSE.Pagamentos.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            services.AddScoped<IPagamentoService, PagamentoService>();
            services.AddScoped<IPagamentoFacade, PagamentoCartaoCreditoFacade>();

            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<PagamentosContext>();
        }
    }
}

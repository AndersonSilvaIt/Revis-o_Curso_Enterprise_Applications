using NSE.Core.Mediator;
using NSE.Pedido.Domain.Vouchers;
using NSE.Pedido.Infra.Data.Repository;
using NSE.Pedido.Infra.Data;
using NSE.WebAPI.Core.Usuario;
using NSE.Pedido.API.Application.Queries;

namespace NSE.Pedido.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            // Application
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IVoucherQueries, VoucherQueries>();

            //Data
            services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<PedidosContext>();
        }
    }
}
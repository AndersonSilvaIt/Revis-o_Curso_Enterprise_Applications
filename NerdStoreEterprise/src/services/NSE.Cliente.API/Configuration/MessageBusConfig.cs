using NSE.MessageBus;
using NSE.Core.Utils;
using NSE.Cliente.API.Services;

namespace NSE.Cliente.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"));
            services.AddHostedService<RegistroClienteIntegrationHandler>();
        }
    }
}
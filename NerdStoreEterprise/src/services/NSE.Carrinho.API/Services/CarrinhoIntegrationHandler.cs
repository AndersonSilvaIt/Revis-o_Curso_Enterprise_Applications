﻿using Microsoft.EntityFrameworkCore;
using NSE.Carrinho.API.Data;
using NSE.Core.Messages.Integration;
using NSE.MessageBus;

namespace NSE.Carrinho.API.Services
{
    public class CarrinhoIntegrationHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public CarrinhoIntegrationHandler(IMessageBus bus, IServiceProvider seerviceProvider)
        {
            _bus = bus;
            _serviceProvider = seerviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetSubscribers();
            return Task.CompletedTask;
        }

        private void SetSubscribers()
        {
            _bus.SubscribeAsync<PedidoRealizadoIntegrationEvent>("PedidoRealizado", async request =>
            {
                await ApagarCarrinho(request);
            });
        }

        private async Task ApagarCarrinho(PedidoRealizadoIntegrationEvent message)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<CarrinhoContext>();

            var carrinho = await context.CarrinhoCliente.FirstOrDefaultAsync(c => c.ClienteId == message.ClientId);

            if(carrinho != null)
            {
                context.CarrinhoCliente.Remove(carrinho);
                await context.SaveChangesAsync();
            }
        }
    }
}
using FluentValidation.Results;
using MediatR;
using NSE.Core.Messages;

namespace NSE.Pedidos.API.Application.Commands
{
    public class PedidoCommandHandler : CommandHandler, IRequestHandler<AdicionarPedidoCommand, ValidationResult>
    {
        public Task<ValidationResult> Handle(AdicionarPedidoCommand message, CancellationToken cancellationToken)
        {
            // Vaslidação do comando

            // Mapear Pedido

            // Aplicar voucher se houver

            // Validar pedido

            // Processar pagamento

            // Se pagamento tudo ok!

            // Adicionar evento

            // Adicionar Pedido repositorio

            //Persistir ddos de pedido e voucher

            throw new NotImplementedException();
        }
    }
}
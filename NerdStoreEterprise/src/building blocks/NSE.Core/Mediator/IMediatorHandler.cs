using FluentValidation.Results;
using NSE.Core.Messages;

namespace NSE.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T Evento) where T : Event;
        Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
    }
}
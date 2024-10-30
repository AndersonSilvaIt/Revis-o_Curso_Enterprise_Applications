using FluentValidation;
using FluentValidation.Results;
using NSE.Core.Messages;

namespace NSE.Cliente.API.Application.Commands
{
    public class RegistrarClienteCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }

        public RegistrarClienteCommand(Guid id, string nome, string email, string cpf)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }

        public override bool EhValido()
        {
            ValidationResult = new RegistrarClienteValildation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RegistrarClienteValildation : AbstractValidator<RegistrarClienteCommand>
    {
        public RegistrarClienteValildation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome do cliente não foi informado");

            RuleFor(c => c.Cpf)
                .Must(TerCpfValido)
                .WithMessage("O CPF informado não é válido.");

            RuleFor(c => c.Email)
                .Must(TerEmailVallido)
                .WithMessage("O e-mail informado não é válido.");
        }

        protected static bool TerCpfValido(string cpf)
        {
            return Core.DomainObjects.Cpf.Validar(cpf);
        }

        protected static bool TerEmailVallido(string email)
        {
            return Core.DomainObjects.Email.Validar(email);
        }
    }
}
using Crosscuting.Funcoes;
using Dominio.Entidades;
using Dominio.Validators.MessagensValidator;
using FluentValidation;

namespace Dominio.Validators.EntidadesValidator
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("Nome"))
                                .MaximumLength(100).WithMessage(MensagemValidator.NaoMaior("Nome"));
            RuleFor(x => x.Telefone).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("Telefone"))
                                .MaximumLength(11).WithMessage(MensagemValidator.NaoMaior("Telefone"));
            RuleFor(x => x.Cpf).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("CPF"))
                                .Must(ValidadorCpf.ValidarCpf).WithMessage("CPF inválido.");
        }
    }
}

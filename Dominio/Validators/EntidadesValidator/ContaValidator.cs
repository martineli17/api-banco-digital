using Dominio.Entidades;
using Dominio.Validators.MessagensValidator;
using FluentValidation;

namespace Dominio.Validators.EntidadesValidator
{
    public class ContaValidator : AbstractValidator<Conta>
    {
        public ContaValidator()
        {
            RuleFor(x => x.IdCliente).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("Cliente"));
            RuleFor(x => x.Numero).Length(11).WithMessage(MensagemValidator.ErroNoProcesso);
            RuleFor(x => x.Saldo).GreaterThanOrEqualTo(0).WithMessage(MensagemValidator.ErroNoProcesso);
        }
    }
}

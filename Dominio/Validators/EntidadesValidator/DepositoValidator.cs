using Dominio.Entidades;
using Dominio.Validators.EntidadesValidator.Base;
using Dominio.Validators.MessagensValidator;
using FluentValidation;

namespace Dominio.Validators.EntidadesValidator
{
    public class DepositoValidator : AbstractValidator<Deposito>
    {
        public DepositoValidator()
        {
            RuleFor(x => x).SetValidator(new OperacaoBaseValidator());
            RuleFor(x => x.NumeroBoleto).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("Boleto"));
            RuleFor(x => x.Credenciador).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("Credenciador"));
        }
    }
}

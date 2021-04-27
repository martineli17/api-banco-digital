using Dominio.Entidades;
using Dominio.Validators.EntidadesValidator.Base;
using Dominio.Validators.MessagensValidator;
using FluentValidation;

namespace Dominio.Validators.EntidadesValidator
{
    public class TransferenciaValidator : AbstractValidator<Transferencia>
    {
        public TransferenciaValidator()
        {
            RuleFor(x => x).SetValidator(new OperacaoBaseValidator());
            RuleFor(x => x.IdContaDestino).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("Conta de origem"));
            RuleFor(x => x.ContaDestino).NotNull().WithMessage("Conta de origem não existente.");
        }
    }
}

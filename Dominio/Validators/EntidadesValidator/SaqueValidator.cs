using Dominio.Entidades;
using Dominio.Validators.EntidadesValidator.Base;
using Dominio.Validators.MessagensValidator;
using FluentValidation;

namespace Dominio.Validators.EntidadesValidator
{
    public class SaqueValidator : AbstractValidator<Saque>
    {
        public SaqueValidator()
        {
            RuleFor(x => x).SetValidator(new OperacaoBaseValidator());
            RuleFor(x => x.IdentificadorCaixaEletronico).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("Caixa eletrônico"));
        }
    }
}

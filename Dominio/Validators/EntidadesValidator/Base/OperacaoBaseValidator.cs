using Dominio.Entidades.Bases;
using Dominio.Validators.MessagensValidator;
using FluentValidation;

namespace Dominio.Validators.EntidadesValidator.Base
{
    public class OperacaoBaseValidator : AbstractValidator<OperacaoBase>
    {
        public OperacaoBaseValidator()
        {
            RuleFor(x => x.Valor).NotEmpty().WithMessage(MensagemValidator.NaoMenorOuIgual("Valor"));
            RuleFor(x => x.IdConta).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("Conta"));
        }
    }
}

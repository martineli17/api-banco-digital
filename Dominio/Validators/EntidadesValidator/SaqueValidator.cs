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
            RuleFor(x => x.Movimentacao.Conta.Saldo).GreaterThanOrEqualTo(x => x.Valor).WithMessage(x => $"Saldo insuficiente. Valor disponível: {x.Movimentacao.Conta.Saldo.ToString("N2")}");
        }
    }
}

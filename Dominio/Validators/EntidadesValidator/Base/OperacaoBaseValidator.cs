using Dominio.Entidades.Bases;
using Dominio.Validators.MessagensValidator;
using FluentValidation;

namespace Dominio.Validators.EntidadesValidator.Base
{
    public class OperacaoBaseValidator : AbstractValidator<OperacaoBase>
    {
        public OperacaoBaseValidator()
        {
            RuleFor(x => x.Movimentacao.Valor).GreaterThan(0).WithMessage(MensagemValidator.NaoMenorOuIgual("Valor"));
            RuleFor(x => x.Movimentacao.IdConta).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("Conta"));
            RuleFor(x => x.Movimentacao.Conta).NotNull().WithMessage("Conta não existente.");
            RuleFor(x => x.Movimentacao.Conta.Ativo).Must(value => value).WithMessage("Operação inválida. Conta está desativada no momento.");
        }
    }
}

using Dominio.Entidades;
using Dominio.Validators.EntidadesValidator.Base;
using Dominio.Validators.MessagensValidator;
using FluentValidation;
using System;

namespace Dominio.Validators.EntidadesValidator
{
    public class TransferenciaValidator : AbstractValidator<Transferencia>
    {
        public TransferenciaValidator()
        {
            RuleFor(x => x).SetValidator(new OperacaoBaseValidator());
            RuleFor(x => x.IdContaDestino).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("Conta de origem"));
            RuleFor(x => x.ContaDestino).NotNull().WithMessage("Conta de origem não existente.");
            RuleFor(x => x.Movimentacao.Conta.Saldo).GreaterThanOrEqualTo(x => x.Movimentacao.Valor).WithMessage(x => $"Saldo insuficiente. Valor disponível: {x.Movimentacao.Conta.Saldo.ToString("N2")}");
        }
    }
}

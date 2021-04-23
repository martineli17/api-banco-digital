using Dominio.Entidades;
using Dominio.Validators.MessagensValidator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Validators.EntidadesValidator
{
    public class ContaValidator : AbstractValidator<Conta>
    {
        public ContaValidator()
        {
            RuleFor(x => x.IdCliente).NotEmpty().WithMessage(MensagemValidator.ErroNoProcesso);
            RuleFor(x => x.Numero).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("Número"))
                .MaximumLength(50).WithMessage(MensagemValidator.NaoMaior("Número"));
            RuleFor(x => x.Saldo).NotNull().WithMessage(MensagemValidator.NaoNuloOuVazio("Saldo")).
                NotEmpty().WithMessage(MensagemValidator.ErroNoProcesso);
        }
    }
}

using Dominio.Entidades;
using Dominio.Validators.MessagensValidator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Validators.EntidadesValidator
{
    public class AgenciaValidator : AbstractValidator<Agencia>
    {
        public AgenciaValidator()
        {
            RuleFor(x => x.Numero).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("Número"))
                .MaximumLength(50).WithMessage(MensagemValidator.NaoMaior("Número"));
        }
    }
}

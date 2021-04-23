using Dominio.Entidades;
using Dominio.Validators.MessagensValidator;
using FluentValidation;

namespace Dominio.Validators.EntidadesValidator
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.IdConta).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("Conta"));
        }
    }
}

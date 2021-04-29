using Dominio.Entidades;
using Dominio.Validators.MessagensValidator;
using FluentValidation;

namespace Dominio.Validators.EntidadesValidator
{
    public class CartaoValidator : AbstractValidator<Cartao>
    {
        public CartaoValidator()         
        {                                                                                                    
            RuleFor(x => x.IdCliente).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("Cliente"));
            RuleFor(x => x.Tipo).IsInEnum();
        }
    }
}

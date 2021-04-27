using Crosscuting.Notificacao;
using Dominio.Interfaces.Repositorio.Bases;
using Service.Validators.ValidadorBase;

namespace Service.Services.ServicesBase
{
    public class InjectorServiceBase
    {
        public readonly IValidacaoFluent Validator;
        public readonly INotificador Notificador;
        public readonly IUnitOfWork UnitOfWork;
        public InjectorServiceBase(IValidacaoFluent validator, INotificador notificador, IUnitOfWork unitOfWork)
        {
            Validator = validator;
            Notificador = notificador;
            UnitOfWork = unitOfWork;
        }
    }
}

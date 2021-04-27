using Crosscuting.Notificacao;
using Dominio.Interfaces.Repositorio.Bases;

namespace Service.Services.ServicesBase
{
    public class InjectorServiceBase
    {
        public readonly INotificador Notificador;
        public readonly IUnitOfWork UnitOfWork;
        public InjectorServiceBase(INotificador notificador, IUnitOfWork unitOfWork)
        {
            Notificador = notificador;
            UnitOfWork = unitOfWork;
        }
    }
}

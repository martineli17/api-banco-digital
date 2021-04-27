using Dominio.Entidades;
using Dominio.Interfaces.Service.Bases;

namespace Dominio.Interfaces.Service
{
    public interface ITransferenciaService : IBaseUpdateService<Transferencia>, IBaseAddService<Transferencia>, IBaseRemoveService, IBaseQueryService<Transferencia>
    {
    }
}

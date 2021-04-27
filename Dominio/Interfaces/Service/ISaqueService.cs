using Dominio.Entidades;
using Dominio.Interfaces.Service.Bases;

namespace Dominio.Interfaces.Service
{
    public interface ISaqueService : IBaseAddService<Saque>, IBaseQueryService<Saque>
    {
    }
}

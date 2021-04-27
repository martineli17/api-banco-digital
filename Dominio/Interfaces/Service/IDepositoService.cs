using Dominio.Entidades;
using Dominio.Interfaces.Service.Bases;

namespace Dominio.Interfaces.Service
{
    public interface IDepositoService : IBaseAddService<Deposito>, IBaseQueryService<Deposito>
    {
    }
}

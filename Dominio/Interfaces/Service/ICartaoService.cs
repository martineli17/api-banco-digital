using Dominio.Entidades;
using Dominio.Interfaces.Service.Bases;

namespace Dominio.Interfaces.Service
{
    public interface ICartaoService : IBaseAddService<Cartao>, IBaseQueryService<Cartao>
    {
    }
}

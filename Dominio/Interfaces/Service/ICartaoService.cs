using Dominio.Entidades;
using Dominio.Interfaces.Service.Bases;
using Dominio.ValuesType;
using System;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Service
{
    public interface ICartaoService : IBaseAddService<Cartao>, IBaseQueryService<Cartao>
    {
        Task<bool> StatusAsync(Guid idCartao, bool status);
        Task<bool> MudarTiporAsync(Guid idCartao, EnumTipoCartao tipo);
    }
}

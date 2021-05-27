using Dominio.Entidades;
using Dominio.Interfaces.Service.Bases;
using Dominio.ValuesType;
using System;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Service
{
    public interface IContaService : IBaseAddService<Conta>, IBaseQueryService<Conta>
    {
        Task<Conta> UpdateTipoAsync(Guid id, EnumTipoConta tipo);
        Task<Conta> UpdateStatusAsync(Guid id, bool ativo);
    }
}

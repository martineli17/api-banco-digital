using System.Threading.Tasks;

namespace Dominio.Interfaces.Repositorio.Bases
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}

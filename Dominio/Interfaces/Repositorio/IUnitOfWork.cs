using System.Threading.Tasks;

namespace Dominio.Interfaces.Repositorio
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}

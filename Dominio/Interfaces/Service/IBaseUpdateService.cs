using System.Threading.Tasks;

namespace Dominio.Interfaces.Service
{
    public interface IBaseUpdateService<TEntidade> where TEntidade : class
    {
        Task<TEntidade> AddAsync(TEntidade entidade);
    }
}

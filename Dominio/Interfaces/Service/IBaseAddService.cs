using System.Threading.Tasks;

namespace Dominio.Interfaces.Service
{
    public interface IBaseAddService<TEntidade> where TEntidade : class
    {
        Task<TEntidade> AddAsync(TEntidade entidade);
    }
}

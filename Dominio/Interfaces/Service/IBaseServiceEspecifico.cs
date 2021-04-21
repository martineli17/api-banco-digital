using System.Threading.Tasks;

namespace Dominio.Interfaces.Service
{
    public interface IBaseServiceEspecifico<TEntidade> where TEntidade : class
    {
        Task<TEntidade> AddAsync(TEntidade entidade);
        Task<TEntidade> UpdateAsync(TEntidade entidade);
    }
}

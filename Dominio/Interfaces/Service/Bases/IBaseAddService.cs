using System.Threading.Tasks;

namespace Dominio.Interfaces.Service.Bases
{
    public interface IBaseAddService<TEntidade> where TEntidade : class
    {
        Task<TEntidade> AddAsync(TEntidade entidade);
    }
}

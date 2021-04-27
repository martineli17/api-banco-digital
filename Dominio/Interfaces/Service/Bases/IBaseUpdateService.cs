using System.Threading.Tasks;

namespace Dominio.Interfaces.Service.Bases
{
    public interface IBaseUpdateService<TEntidade> where TEntidade : class
    {
        Task<TEntidade> UpdateAsync(TEntidade entidade);
    }
}

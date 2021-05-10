using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Service.Bases
{
    public interface IBaseQueryService<TEntidade> where TEntidade : class
    {
        Task<IQueryable<TEntidade>> GetAsync(Expression<Func<TEntidade, bool>> query = null, params string[] includes);
        Task<TEntidade> GetByIdAsync(Guid id, params string[] includes);
    }
}

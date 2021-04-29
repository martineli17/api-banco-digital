using Dominio.Entidades.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Repositorio.Bases
{
    public interface IBaseRepositorio<TEntidade> where TEntidade : Base
    {
        Task AddAsync(TEntidade entidade);
        Task AddAsync(IEnumerable<TEntidade> entidade);
        Task RemoveAsync(Guid id);
        Task RemoveAsync(IEnumerable<Guid> id);
        Task UpdateAsync(TEntidade entidade);
        Task UpdateAsync(IEnumerable<TEntidade> entidade);
        Task UpdatePropsAsync(TEntidade entidade, params string[] propriedades);
        Task UpdatePropsAsync(IEnumerable<TEntidade> entidade, params string[] propriedades);
        Task<IQueryable<TEntidade>> GetAsync(Expression<Func<TEntidade, bool>> query = null, params string[] includes);
        Task<bool> ExistsAsync(Expression<Func<TEntidade, bool>> query);
        Task<TEntidade> GetByIdAsync(Guid id);
    }
}

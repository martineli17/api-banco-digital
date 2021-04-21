using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Repositorio
{
    public interface IBaseRepositorio<TEntidade> where TEntidade : Base
    {
        Task AddAsync(TEntidade entidade);
        Task AddAsync(IEnumerable<TEntidade> entidade);
        Task RemoveAsync(Guid id);
        Task RemoveAsync(IEnumerable<Guid> id);
        Task UpdateAsync(TEntidade entidade);
        Task UpdateAsync(IEnumerable<TEntidade> entidade);
        Task<IQueryable<TEntidade>> GetAsync(Expression<Func<TEntidade, bool>> query = null);
        Task<bool> ExistsAsync(Expression<Func<TEntidade, bool>> query);
        Task<TEntidade> GetByIdAsync(Guid id);
    }
}

using Crosscuting.Extensions;
using Dominio.Entidades.Bases;
using Dominio.Interfaces.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositorio.Repositorios.Bases
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : Base
    {
        protected readonly InjectorRepositorio Injector;

        public BaseRepositorio(InjectorRepositorio injector)
        {
            Injector = injector;
        }

        public virtual async Task AddAsync(TEntity entidade)
        {
            await Injector.Context.Set<TEntity>().AddAsync(entidade);
        }

        public virtual async Task AddAsync(IEnumerable<TEntity> entidades)
        {
            await Injector.Context.Set<TEntity>().AddRangeAsync(entidades);
        }

        public virtual async Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, params string[] includes)
        {
            await Task.Yield();
            var query = Injector.Context.Set<TEntity>().AsQueryable();
            if (includes.HasValue())
                foreach (var include in includes)
                    query = query.Include(include);
            if (filter != null)
                query.Where(filter);
            return query;
        }
        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> query)
        {
            await Task.Yield();
            return await Injector.Context.Set<TEntity>().AnyAsync(query);
        }
        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            var entidade = await Injector.Context.Set<TEntity>().FindAsync(id);
            if (entidade != null)
                Injector.Context.Entry(entidade).State = EntityState.Detached;
            return entidade;
        }

        public virtual async Task RemoveAsync(Guid id)
        {
            var entidade = await GetByIdAsync(id);
            if (entidade == null)
            {
                Injector.Notificador.Add("Registro não encontrado.");
                return;
            }
            Injector.Context.Set<TEntity>().Remove(entidade);
        }

        public virtual async Task RemoveAsync(IEnumerable<Guid> id)
        {
            await Task.Yield();
            var entidades = Injector.Context.Set<TEntity>().Where(x => id.Contains(x.Id));
            Injector.Context.Set<TEntity>().RemoveRange(entidades);
        }

        public virtual async Task UpdateAsync(TEntity entidade)
        {
            await Task.Yield();
            Injector.Context.Set<TEntity>().Update(entidade);
        }

        public virtual async Task UpdateAsync(IEnumerable<TEntity> entidades)
        {
            await Task.Yield();
            Injector.Context.Set<TEntity>().UpdateRange(entidades);
        }
    }
}

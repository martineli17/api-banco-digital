using Dominio.Entidades.Bases;
using Dominio.Interfaces.Repositorio.Bases;
using Service.Services.ServicesBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Service.Services.Bases
{
    public class BaseService<TEntidade> where TEntidade : Base
    {
        protected readonly IBaseRepositorio<TEntidade> Repositorio;
        protected readonly InjectorServiceBase Injector;

        public BaseService(IBaseRepositorio<TEntidade> repositorio, InjectorServiceBase injector)
        {
            Repositorio = repositorio;
            Injector = injector;
        }

        public virtual async Task<IQueryable<TEntidade>> GetAsync(Expression<Func<TEntidade, bool>> query = null, params string[] includes)
            => await Repositorio.GetAsync(query, includes);

        public virtual async Task<TEntidade> GetByIdAsync(Guid id, params string[] includes) 
        {
            var entidade = await Repositorio.GetByIdAsync(id, includes);
            if (entidade is null)
                Injector.Notificador.Add("Registro solicitado não encontrado.");
            return entidade;
        }

        protected async Task<TEntidade> AddAsync(TEntidade entidade)
        {
            await Repositorio.AddAsync(entidade);
            return entidade;
        }

        protected async Task<IEnumerable<TEntidade>> AddAsync(IEnumerable<TEntidade> entidade)
        {
            await Repositorio.AddAsync(entidade);
            return entidade;
        }

        protected async Task<bool> RemoveAsync(Guid id)
        {
            if (!await ValidarExistenciaEntidadeAsync(id))
                return false;
            await Repositorio.RemoveAsync(id);
            return true;
        }

        protected async Task<TEntidade> UpdateAsync(TEntidade entidade)
        {
            if (!await ValidarExistenciaEntidadeAsync(entidade.Id))
                return null;
            await Repositorio.UpdateAsync(entidade);
            return entidade;
        }

        protected async Task<bool> ValidarExistenciaEntidadeAsync(Guid id)
        {
            if (!await Repositorio.ExistsAsync(x => x.Id == id))
            {
                Injector.Notificador.Add("Registro solicitado não encontrado.");
                return false;
            }
            return true;
        }

        protected bool ValidarExistenciaEntidadeAsync(TEntidade entidade)
        {
            if (entidade != null)
            {
                Injector.Notificador.Add("Registro solicitado não encontrado.");
                return false;
            }
            return true;
        }

        protected async Task<bool> ValidarExistenciaEntidadeAsync(Expression<Func<TEntidade, bool>> filter)
            => await Repositorio.ExistsAsync(filter);

        protected async Task<bool> CommitAsync() => await Injector.UnitOfWork.CommitAsync();

        protected bool ValidarEntidade(TEntidade entidade)
        {
            var validacaoEntidade = entidade.Validar();
            if (!validacaoEntidade.IsValido)
                Injector.Notificador.AddRange(validacaoEntidade.Erros);
            return validacaoEntidade.IsValido;
        }
    }
}

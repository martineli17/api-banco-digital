using Crosscuting.Extensions;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Service;
using Dominio.Validators.EntidadesValidator;
using Service.Services.Bases;
using Service.Services.ServicesBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ContaService : BaseService<Conta>, IContaService
    {
        public ContaService(IContaRepositorio repositorio, InjectorServiceBase injector)
        : base(repositorio, injector)
        {
        }

        public new async Task<Conta> AddAsync(Conta entidade)
        {
            if (!base.ValidarEntidade(entidade)) return null;

            if (!await ValidarContaDuplicada(entidade))
                return entidade;
            await base.AddAsync(entidade);
            return entidade;
        }

        public new async Task<Conta> UpdateAsync(Conta entidade)
        {
            if (!await ValidarContaDuplicada(entidade, true))
                return entidade;
            await base.UpdateAsync(entidade);
            return entidade;
        }

        public new async Task<bool> RemoveAsync(Guid id)
        {
            if (await base.ValidarExistenciaEntidadeAsync(x => x.Id == id))
                return false;
            await base.RemoveAsync(id);
            return await base.CommitAsync();
        }

        private async Task<bool> ValidarContaDuplicada(Conta entidade, bool update = false)
        {
            if (entidade == null ||
                (await Repositorio.GetAsync(x => (!update || x.Id != entidade.Id)
                && ((x.Numero == entidade.Numero)))).HasValue())
            {
                Injector.Notificador.Add("Conta já registrada.");
                return false;
            }
            return true;
        }
    }
}

using Crosscuting.Extensions;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Service;
using Dominio.Validators.MessagensValidator;
using Dominio.ValuesType;
using Service.Services.Bases;
using Service.Services.ServicesBase;
using System;
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
            await base.CommitAsync();
            return entidade;
        }

        public async Task<Conta> UpdateTipoAsync(Guid id, EnumTipoConta tipo)
        {
            var entidade = await base.GetByIdAsync(id);
            if (!base.ValidarEntidade(entidade))
                return null;
            entidade.Tipo = tipo;
            await base.Repositorio.UpdatePropsAsync(entidade, nameof(Conta.Tipo));
            await base.CommitAsync();
            return entidade;
        }

        public async Task<Conta> UpdateStatusAsync(Guid id, bool ativo)
        {
            var entidade = await base.GetByIdAsync(id);
            if (!base.ValidarEntidade(entidade))
                return null;
            entidade.Ativo = ativo;
            await base.Repositorio.UpdatePropsAsync(entidade, nameof(Conta.Ativo));
            await base.CommitAsync();
            return entidade;
        }

        #region Métodos Privados
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
        #endregion
    }
}

using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Repositorio.Bases;
using Dominio.Interfaces.Service;
using Dominio.Interfaces.Service.Bases;
using Dominio.Validators.MessagensValidator;
using Service.Services.Bases;
using Service.Services.ServicesBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteService(IClienteRepositorio repositorio, InjectorServiceBase injector) : base(repositorio, injector)
        {
        }

        public new async Task<Cliente> AddAsync(Cliente entidade)
        {
            if (!base.ValidarEntidade(entidade)) return null;
            
            await base.AddAsync(entidade);
            await base.CommitAsync();
            return entidade;
        }

        public new async Task<Cliente> UpdateAsync(Cliente entidade)
        {
            if (!base.ValidarEntidade(entidade)) return null;
            await base.UpdateAsync(entidade);
            await base.CommitAsync();
            return entidade;
        }

        public new async Task<bool> RemoveAsync(Guid id)
        {
            if (!await base.ValidarExistenciaEntidadeAsync(id))
                return false;
            await base.RemoveAsync(id);
            return await base.CommitAsync();
        }
    }
}

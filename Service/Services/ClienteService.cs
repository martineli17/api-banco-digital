﻿using Dominio.Entidades;
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
        public ClienteService(IBaseRepositorio<Cliente> repositorio, InjectorServiceBase injector, IClienteRepositorio clienteRepositorio) : base(repositorio, injector)
        {
            _clienteRepositorio = clienteRepositorio;
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
            if (await base.ValidarExistenciaEntidadeAsync(entidade.Id))
            {
                Injector.Notificador.Add("Não é possível atualizar este cliente.");
                return null;
            }

            if (!base.ValidarEntidade(entidade)) return null;

            await base.UpdateAsync(entidade);
            await base.CommitAsync();
            return entidade;
        }

        public new async Task<bool> RemoveAsync(Guid id)
        {
            if (await base.ValidarExistenciaEntidadeAsync(id))
                return false;
            await base.RemoveAsync(id);
            //Remover Conta relacionada ao cliente  
            //Remover Cartao relacionado ao cliente 
            return await base.CommitAsync();
        }
    }
}
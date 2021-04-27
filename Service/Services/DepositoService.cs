﻿using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Repositorio.Bases;
using Dominio.Interfaces.Service;
using Service.Services.Bases;
using Service.Services.ServicesBase;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DepositoService : BaseService<Deposito>, IDepositoService
    {
        private readonly IContaRepositorio _contaRepositorio;
        public DepositoService(IBaseRepositorio<Deposito> repositorio, InjectorServiceBase injector,
                               IContaRepositorio contaRepositorio)
            : base(repositorio, injector)
        {
            _contaRepositorio = contaRepositorio;
        }

        public new async Task<Deposito> AddAsync(Deposito entidade)
        {
            entidade.Movimentacao.Conta = await _contaRepositorio.GetByIdAsync(entidade.IdConta);
            if (!base.ValidarEntidade(entidade)) return null;
            entidade.Depositar();
            await base.AddAsync(entidade);
            await base.CommitAsync();
            return entidade;
        }
    }
}
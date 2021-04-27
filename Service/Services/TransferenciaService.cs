using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Repositorio.Bases;
using Dominio.Interfaces.Service;
using Service.Services.Bases;
using Service.Services.ServicesBase;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class TransferenciaService : BaseService<Transferencia>, ITransferenciaService
    {
        private readonly IContaRepositorio _contaRepositorio;
        public TransferenciaService(IBaseRepositorio<Transferencia> repositorio, InjectorServiceBase injector, 
                                    IContaRepositorio contaRepositorio)
            : base(repositorio, injector)
        {
            _contaRepositorio = contaRepositorio;
        }

        public new async Task<Transferencia> UpdateAsync(Transferencia entidade)
        {
            if (await base.ValidarExistenciaEntidadeAsync(x => x.Id == entidade.Id && x.DataAgendamento <= DateTime.Now))
            {
                Injector.Notificador.Add("Não é mais possível atualizar esta transferência.");
                return null;
            }
            var contas = (await _contaRepositorio.GetAsync(x => x.Id == entidade.IdConta || x.Id == entidade.IdContaDestino)).ToList();
            entidade.ContaDestino = contas?.FirstOrDefault(x => x.Id == entidade.IdContaDestino);
            entidade.Movimentacao.Conta = contas?.FirstOrDefault(x => x.Id == entidade.IdConta);
            if (!base.ValidarEntidade(entidade)) return null;
            entidade.Transferir();
            await base.UpdateAsync(entidade);
            await base.CommitAsync();
            return entidade;
        }

        public new async Task<Transferencia> AddAsync(Transferencia entidade)
        {
            var contas = (await _contaRepositorio.GetAsync(x => x.Id == entidade.IdConta || x.Id == entidade.IdContaDestino)).ToList();
            entidade.ContaDestino = contas?.FirstOrDefault(x => x.Id == entidade.IdContaDestino);
            entidade.Movimentacao.Conta = contas?.FirstOrDefault(x => x.Id == entidade.IdConta);
            if (!base.ValidarEntidade(entidade)) return null;
            entidade.Transferir();
            await base.AddAsync(entidade);
            await base.CommitAsync();
            return entidade;
        }

        public new async Task<bool> RemoveAsync(Guid id)
        {
            if (await base.ValidarExistenciaEntidadeAsync(x => x.Id == id && x.DataAgendamento > DateTime.Now))
                return false;
            await base.RemoveAsync(id);
            return await base.CommitAsync();
        }
    }
}

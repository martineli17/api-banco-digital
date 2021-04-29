using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Repositorio.Bases;
using Dominio.Interfaces.Service;
using Service.Services.Bases;
using Service.Services.ServicesBase;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SaqueService : BaseService<Saque>, ISaqueService
    {
        private readonly IContaRepositorio _contaRepositorio;
        private readonly ICartaoRepositorio _cartaoRepositorio;
        public SaqueService(IBaseRepositorio<Saque> repositorio, InjectorServiceBase injector,
                            IContaRepositorio contaRepositorio, ICartaoRepositorio cartaoRepositorio)
            : base(repositorio, injector)
        {
            _contaRepositorio = contaRepositorio;
            _cartaoRepositorio = cartaoRepositorio;
        }

        public new async Task<Saque> AddAsync(Saque entidade)
        {
            entidade.Movimentacao.Conta = await _contaRepositorio.GetByIdAsync(entidade.IdConta);
            if (!base.ValidarEntidade(entidade)) return null;
            if(await _cartaoRepositorio.ExistsAsync(x => !x.Ativo && x.IdCliente == entidade.Movimentacao.Conta.IdCliente))
            {
                Injector.Notificador.Add("Saque não disponível. Cartão foi desativado.");
                return null;
            }
            entidade.Sacar();
            await base.AddAsync(entidade);
            await base.CommitAsync();
            return entidade;
        }
    }
}

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
        public SaqueService(IBaseRepositorio<Saque> repositorio, InjectorServiceBase injector,
                            IContaRepositorio contaRepositorio)
            : base(repositorio, injector)
        {
            _contaRepositorio = contaRepositorio;
        }

        public new async Task<Saque> AddAsync(Saque entidade)
        {
            entidade.Movimentacao.Conta = await _contaRepositorio.GetByIdAsync(entidade.IdConta);
            if (!base.ValidarEntidade(entidade)) return null;
            entidade.Sacar();
            await base.AddAsync(entidade);
            await base.CommitAsync();
            return entidade;
        }
    }
}

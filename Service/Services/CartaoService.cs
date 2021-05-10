using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Repositorio.Bases;
using Dominio.Interfaces.Service;
using Dominio.Validators.MessagensValidator;
using Dominio.ValuesType;
using Service.Services.Bases;
using Service.Services.ServicesBase;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CartaoService : BaseService<Cartao>, ICartaoService
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public CartaoService(ICartaoRepositorio repositorio, InjectorServiceBase injector,
                             IClienteRepositorio clienteRepositorio) 
            : base(repositorio, injector)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public override Task<IQueryable<Cartao>> GetAsync(Expression<Func<Cartao, bool>> query = null, params string[] includes)
            => base.GetAsync(query, nameof(Cartao.Cliente));

        public override Task<Cartao> GetByIdAsync(Guid id, params string[] includes)
            => base.GetByIdAsync(id, nameof(Cartao.Cliente));

        public new async Task<Cartao> AddAsync(Cartao entidade)
        {
            if (!base.ValidarEntidade(entidade)) return null;
            if (!await _clienteRepositorio.ExistsAsync(x => x.Id == entidade.IdCliente))
            {
                Injector.Notificador.Add(MensagemValidator.RegistroNaoEncontrado("Cliente"));
                return null;
            }
            entidade.Ativar();
            await base.AddAsync(entidade);
            await base.CommitAsync();
            return entidade;
        }

        public async Task<bool> StatusAsync(Guid idCartao, bool status)
        {
            if (!await base.ValidarExistenciaEntidadeAsync(x => x.Id == idCartao))
            {
                Injector.Notificador.Add(MensagemValidator.RegistroNaoEncontrado("Cartão"));
                return false;
            }
            var entidade = status ? new Cartao().Ativar() : new Cartao().Desativar();
            entidade.Id = idCartao;
            await Repositorio.UpdatePropsAsync(entidade, nameof(Cartao.Ativo));
            return await base.CommitAsync();
        }

        public async Task<bool> MudarTiporAsync(Guid idCartao, EnumTipoCartao tipo)
        {
            if (!await base.ValidarExistenciaEntidadeAsync(x => x.Id == idCartao))
            {
                Injector.Notificador.Add(MensagemValidator.RegistroNaoEncontrado("Cartão"));
                return false;
            }
            var entidade = new Cartao().MudarTipo(tipo);
            entidade.Id = idCartao;
            await Repositorio.UpdatePropsAsync(entidade, nameof(Cartao.Tipo));
            return await base.CommitAsync();
        }
    }
}

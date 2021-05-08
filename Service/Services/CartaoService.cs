using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Repositorio.Bases;
using Dominio.Interfaces.Service;
using Dominio.Validators.MessagensValidator;
using Service.Services.Bases;
using Service.Services.ServicesBase;
using System;
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

        public async Task<bool> DesativarAsync(Guid idCartao)
        {
            var entidade = await Repositorio.GetByIdAsync(idCartao);
            if (entidade is null)
            {
                Injector.Notificador.Add(MensagemValidator.RegistroNaoEncontrado("Cartão"));
                return false;
            }
            entidade.Desativar();
            await Repositorio.UpdatePropsAsync(entidade, nameof(Cartao.Ativo));
            return await base.CommitAsync();
        }
    }
}

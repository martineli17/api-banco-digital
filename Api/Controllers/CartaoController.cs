using Api.Controllers.Base;
using Api.Core.Constantes;
using Api.Core.DTO.CartaoDTOs;
using Api.Core.Services;
using Crosscuting.Notificacao;
using Dominio.Entidades;
using Dominio.Interfaces.Service;
using Dominio.ValuesType;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route(Urls.Version01 + "cartao")]
    public class CartaoController : BaseController
    {
        private readonly ICartaoService _cartaoService;
        private readonly UserService _userService;
        public CartaoController(BaseControllerInjector injector, 
                                ICartaoService cartaoService,
                                UserService userService)
            : base(injector)
        {
            _cartaoService = cartaoService;
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IQueryable<Cartao>), 200)]
        [ProducesResponseType(typeof(IQueryable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IQueryable<Cartao>>> Get() =>  CustomResponse(await _cartaoService.GetAsync());

        [HttpGet("cliente")]
        [ProducesResponseType(typeof(Cartao), 200)]
        [ProducesResponseType(typeof(IQueryable<MensagemNotificacao>), 404)]
        [ProducesResponseType(typeof(IQueryable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Cartao>> GetByCliente()
        {
            var idCartao = (await _cartaoService.GetAsync(x => x.IdCliente == _userService.GetId())).FirstOrDefault()?.Id;
            if (!idCartao.HasValue)
                return CustomResponse<Cartao>(null, 404, 404);
            var cartao = await _cartaoService.GetByIdAsync(idCartao.Value);
            return CustomResponse(cartao, 200, cartao is null ? 404 : 400);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CartaoAddResponse), 201)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CartaoAddResponse>> Post([FromBody] CartaoAddRequest cartao)
        {
            var entidade = Injector.Mapper.Map<Cartao>(cartao);
            entidade.IdCliente = _userService.GetId();
            entidade = await _cartaoService.AddAsync(entidade);
            return CustomResponse(Injector.Mapper.Map<CartaoAddResponse>(entidade));
        }

        [HttpPut("status/{status}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<bool>> Status([FromRoute] bool status)
        {
            var idCartao = (await _cartaoService.GetAsync(x => x.IdCliente == _userService.GetId())).FirstOrDefault()?.Id;
            if (!idCartao.HasValue)
                return CustomResponse<bool>(false, 404, 404);
            return CustomResponse(await _cartaoService.StatusAsync(idCartao.Value, status));
        }

        [HttpPut("tipo/{tipo}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<bool>> Tipo([FromRoute] EnumTipoCartao tipo)
        {
            var idCartao = (await _cartaoService.GetAsync(x => x.IdCliente == _userService.GetId())).FirstOrDefault()?.Id;
            if(!idCartao.HasValue)
                return CustomResponse<bool>(false, 404, 404);
            return CustomResponse(await _cartaoService.MudarTiporAsync(idCartao.Value, tipo));
        }
    }
}

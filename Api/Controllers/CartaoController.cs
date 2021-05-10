using Api.Controllers.Base;
using Api.Core.Constantes;
using Api.Core.DTO.CartaoDTOs;
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
        public CartaoController(BaseControllerInjector injector, ICartaoService cartaoService)
            : base(injector)
        {
            _cartaoService = cartaoService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IQueryable<Cartao>), 200)]
        [ProducesResponseType(typeof(IQueryable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IQueryable<Cartao>>> Get() => CustomResponse(await _cartaoService.GetAsync());

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IQueryable<Cartao>), 200)]
        [ProducesResponseType(typeof(IQueryable<MensagemNotificacao>), 404)]
        [ProducesResponseType(typeof(IQueryable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Cartao>> Get([FromRoute] Guid id)
        {
            var cliente = await _cartaoService.GetByIdAsync(id);
            return CustomResponse(cliente, 200, cliente is null ? 404 : 400);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CartaoAddResponse), 201)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CartaoAddResponse>> Post([FromBody] CartaoAddRequest cartao)
        {
            var entidade = Injector.Mapper.Map<Cartao>(cartao);
            entidade = await _cartaoService.AddAsync(entidade);
            return CustomResponse(Injector.Mapper.Map<CartaoAddResponse>(entidade));
        }

        [HttpPut("status/{id}/{status}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<bool>> Status([FromRoute] Guid id, [FromRoute] bool status)
            => CustomResponse(await _cartaoService.StatusAsync(id, status));

        [HttpPut("tipo/{id}/{tipo}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<bool>> Tipo([FromRoute] Guid id, [FromRoute] EnumTipoCartao tipo)
            => CustomResponse(await _cartaoService.MudarTiporAsync(id, tipo));
    }
}

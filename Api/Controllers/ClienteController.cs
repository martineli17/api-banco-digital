using Api.Controllers.Base;
using Api.Core.Constantes;
using Api.Core.DTO.ClienteDTOs;
using Crosscuting.Notificacao;
using Dominio.Entidades;
using Dominio.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route(Urls.Version01 + "cliente")]
    public class ClienteController : BaseController
    {
        private readonly IClienteService _clienteService;
        public ClienteController(BaseControllerInjector injector, IClienteService clienteService)
            : base(injector)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IQueryable<Cliente>), 200)]
        [ProducesResponseType(typeof(IQueryable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IQueryable<Cliente>>> Get() => CustomResponse(await _clienteService.GetAsync());

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IQueryable<Cliente>), 200)]
        [ProducesResponseType(typeof(IQueryable<MensagemNotificacao>), 404)]
        [ProducesResponseType(typeof(IQueryable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Cliente>> Get([FromRoute] Guid id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            return CustomResponse(cliente, 200, cliente is null ? 404 : 400);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClienteAddResponse), 201)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ClienteAddResponse>> Post([FromBody] ClienteAddRequest cliente)
        {
            var entidade = Injector.Mapper.Map<Cliente>(cliente);
            entidade = await _clienteService.AddAsync(entidade);
            return CustomResponse(Injector.Mapper.Map<ClienteAddResponse>(entidade));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ClienteUpdateResponse), 200)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ClienteUpdateResponse>> Put([FromBody] ClienteUpdateRequest cliente)
        {
            var entidade = Injector.Mapper.Map<Cliente>(cliente);
            entidade = await _clienteService.UpdateAsync(entidade);
            return CustomResponse(Injector.Mapper.Map<ClienteUpdateResponse>(entidade));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<bool>> Delete(Guid id) => CustomResponse(await _clienteService.RemoveAsync(id));
    }
}

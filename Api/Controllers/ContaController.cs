using Api.Controllers.Base;
using Api.Core.Constantes;
using Api.Core.DTO.ContaDTOs;
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
    [Route(Urls.Version01 + "conta")]
    public class ContaController : BaseController
    {
        private readonly IContaService _contaService;

        public ContaController(BaseControllerInjector injector, IContaService contaService)
         : base(injector)
        {
            _contaService = contaService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IQueryable<Conta>), 200)]
        [ProducesResponseType(typeof(IQueryable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IQueryable<Conta>>> Get() => CustomResponse(await _contaService.GetAsync());

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IQueryable<Conta>), 200)]
        [ProducesResponseType(typeof(IQueryable<MensagemNotificacao>), 404)]
        [ProducesResponseType(typeof(IQueryable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Conta>> Get([FromRoute] Guid id)
        {
            var conta = await _contaService.GetByIdAsync(id);
            return CustomResponse(conta, 200, conta is null ? 404 : 400);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ContaAddResponse), 201)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ContaAddResponse>> Post([FromBody] ContaAddRequest conta)
        {
            var entidade = Injector.Mapper.Map<Conta>(conta);
            entidade = await _contaService.AddAsync(entidade);
            return CustomResponse(Injector.Mapper.Map<ContaAddResponse>(entidade));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ContaUpdateResponse), 200)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ContaUpdateResponse>> Put([FromBody] ContaUpdateRequest conta)
        {
            var entidade = Injector.Mapper.Map<Conta>(conta);
            entidade = await _contaService.UpdateAsync(entidade);
            return CustomResponse(Injector.Mapper.Map<ContaUpdateResponse>(entidade));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<bool>> Delete(Guid id) => CustomResponse(await _contaService.RemoveAsync(id));
    }
}

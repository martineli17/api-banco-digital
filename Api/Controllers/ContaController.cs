using Api.Controllers.Base;
using Api.Core.Constantes;
using Api.Core.DTO.ContaDTOs;
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
    [Route(Urls.Version01 + "conta")]
    public class ContaController : BaseController
    {
        private readonly IContaService _contaService;
        private readonly UserService _userService;
        public ContaController(BaseControllerInjector injector, 
                               IContaService contaService,
                               UserService userService)
         : base(injector)
        {
            _contaService = contaService;
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IQueryable<ContaGet>), 200)]
        [ProducesResponseType(typeof(IQueryable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<ContaGet>>> Get()
        {
            var contas = await _contaService.GetAsync(x => true, nameof(Conta.Cliente));
            return CustomResponse(base.Injector.Mapper.Map<IEnumerable<ContaGet>>(contas));
        }
            

        [HttpGet("cliente")]
        [ProducesResponseType(typeof(Conta), 200)]
        [ProducesResponseType(typeof(IQueryable<MensagemNotificacao>), 404)]
        [ProducesResponseType(typeof(IQueryable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Conta>> GetByCliente()
        {
            var conta = (await _contaService.GetAsync(x => x.IdCliente == _userService.GetId())).FirstOrDefault();
            return CustomResponse(conta, conta is null ? 404 : 200);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ContaAddResponse), 201)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ContaAddResponse>> Post([FromBody] ContaAddRequest conta)
        {
            var entidade = Injector.Mapper.Map<Conta>(conta);
            entidade.IdCliente = _userService.GetId();
            entidade = await _contaService.AddAsync(entidade);
            return CustomResponse(Injector.Mapper.Map<ContaAddResponse>(entidade));
        }

        [HttpPut("tipo/{tipo}")]
        [ProducesResponseType(typeof(ContaUpdateResponse), 200)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ContaUpdateResponse>> UpdateTipo([FromRoute] EnumTipoConta tipo)
        {
            var idConta = await GetIdConta();
            if(!idConta.HasValue)
                return CustomResponse<ContaUpdateResponse>(null, 404, 404);
            var entidade = await _contaService.UpdateTipoAsync(idConta.Value, tipo);
            return CustomResponse(Injector.Mapper.Map<ContaUpdateResponse>(entidade));
        }

        [HttpPut("status/{ativo}")]
        [ProducesResponseType(typeof(ContaUpdateResponse), 200)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ContaUpdateResponse>> UpdateAtivo([FromRoute] bool ativo)
        {
            var idConta = await GetIdConta();
            if (!idConta.HasValue)
                return CustomResponse<ContaUpdateResponse>(null, 404, 404);
            var entidade = await _contaService.UpdateStatusAsync(idConta.Value, ativo);
            return CustomResponse(Injector.Mapper.Map<ContaUpdateResponse>(entidade));
        }

        #region Métodos Privados
        private async Task<Guid?> GetIdConta() =>
         (await _contaService.GetAsync(x => x.IdCliente == _userService.GetId())).FirstOrDefault()?.Id;
        #endregion
    }
}

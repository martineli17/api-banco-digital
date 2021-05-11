using Api.Controllers.Base;
using Api.Core.Constantes;
using Api.Core.DTO.OperacaoDTOs;
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
    [Route(Urls.Version01 + "operacao")]
    public class OperacaoController : BaseController
    {
        private readonly Lazy<ISaqueService> _saqueService;
        private readonly Lazy<IDepositoService> _depositoService;
        private readonly Lazy<ITransferenciaService> _transferenciaService;
        public OperacaoController(BaseControllerInjector injector,
                                 Lazy<ISaqueService> saqueService,
                                 Lazy<IDepositoService> depositoService,
                                 Lazy<ITransferenciaService> transferenciaService
                                 )
            : base(injector)
        {
            _saqueService = saqueService;
            _depositoService = depositoService;
            _transferenciaService = transferenciaService;
        }

        [HttpPost("transferencia")]
        [ProducesResponseType(typeof(TransferenciaAddResponse), 200)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<TransferenciaAddResponse>> Transferencia([FromBody] TransferenciaAddRequest transferencia)
        {
            var entidade = Injector.Mapper.Map<Transferencia>(transferencia);
            entidade = await _transferenciaService.Value.AddAsync(entidade);
            return CustomResponse(Injector.Mapper.Map<TransferenciaAddResponse>(entidade), 201);
        }

        [HttpPost("deposito")]
        [ProducesResponseType(typeof(DepositoAddResponse), 201)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<DepositoAddResponse>> Deposito([FromBody] DepositoAddRequest deposito)
        {
            var entidade = Injector.Mapper.Map<Deposito>(deposito);
            entidade = await _depositoService.Value.AddAsync(entidade);
            return CustomResponse(Injector.Mapper.Map<DepositoAddResponse>(entidade), 201);
        }

        [HttpPost("saque")]
        [ProducesResponseType(typeof(DepositoAddResponse), 201)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<SaqueAddResponse>> Saque([FromBody] SaqueAddRequest saque)
        {
            var entidade = Injector.Mapper.Map<Saque>(saque);
            entidade = await _saqueService.Value.AddAsync(entidade);
            return CustomResponse(Injector.Mapper.Map<SaqueAddResponse>(entidade), 201);
        }
    }
}

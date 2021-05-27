using Api.Controllers.Base;
using Api.Core.Constantes;
using Api.Core.DTO.OperacaoDTOs;
using Api.Core.Services;
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
        private readonly UserService _userService;
        private readonly IContaService _contaService;
        private readonly Lazy<ISaqueService> _saqueService;
        private readonly Lazy<IDepositoService> _depositoService;
        private readonly Lazy<ITransferenciaService> _transferenciaService;
        private readonly Lazy<IMovimentacaoService> _movimentacaoService;
        public OperacaoController(BaseControllerInjector injector,
                                 UserService userService,
                                 IContaService contaService,
                                 Lazy<ISaqueService> saqueService,
                                 Lazy<IDepositoService> depositoService,
                                 Lazy<ITransferenciaService> transferenciaService,
                                 Lazy<IMovimentacaoService> movimentacaoService
                                 )
            : base(injector)
        {
            _userService = userService;
            _contaService = contaService;
            _saqueService = saqueService;
            _depositoService = depositoService;
            _transferenciaService = transferenciaService;
            _movimentacaoService = movimentacaoService;
        }

        [HttpPost("transferencia")]
        [ProducesResponseType(typeof(TransferenciaAddResponse), 200)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<TransferenciaAddResponse>> Transferencia([FromBody] TransferenciaAddRequest transferencia)
        {
            var idConta = await GetIdConta();
            if (!idConta.HasValue)
                return CustomResponse<TransferenciaAddResponse>(null, 404, 404);
            var entidade = Injector.Mapper.Map<Transferencia>(transferencia);
            entidade.Movimentacao.IdConta = idConta.Value;
            entidade = await _transferenciaService.Value.AddAsync(entidade);
            return CustomResponse(Injector.Mapper.Map<TransferenciaAddResponse>(entidade), 201);
        }

        [HttpPost("deposito")]
        [ProducesResponseType(typeof(DepositoAddResponse), 201)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<DepositoAddResponse>> Deposito([FromBody] DepositoAddRequest deposito)
        {
            var idConta = await GetIdConta();
            if (!idConta.HasValue)
                return CustomResponse<DepositoAddResponse>(null, 404, 404);
            var entidade = Injector.Mapper.Map<Deposito>(deposito);
            entidade.Movimentacao.IdConta = idConta.Value;
            entidade = await _depositoService.Value.AddAsync(entidade);
            return CustomResponse(Injector.Mapper.Map<DepositoAddResponse>(entidade), 201);
        }

        [HttpPost("saque")]
        [ProducesResponseType(typeof(DepositoAddResponse), 201)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<SaqueAddResponse>> Saque([FromBody] SaqueAddRequest saque)
        {
            var idConta = await GetIdConta();
            if (!idConta.HasValue)
                return CustomResponse<SaqueAddResponse>(null, 404, 404);
            var entidade = Injector.Mapper.Map<Saque>(saque);
            entidade.Movimentacao.IdConta = idConta.Value;
            entidade = await _saqueService.Value.AddAsync(entidade);
            return CustomResponse(Injector.Mapper.Map<SaqueAddResponse>(entidade), 201);
        }

        [HttpGet("movimentacao")]
        [ProducesResponseType(typeof(IQueryable<Movimentacao>), 200)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IQueryable<Movimentacao>>> Movimentacao()
        {
            var idConta = await GetIdConta();
            if (!idConta.HasValue)
                return CustomResponse<IQueryable<Movimentacao>>(null, 404, 404);
            var movimentacoes = await _movimentacaoService.Value.GetAsync(x => x.IdConta == idConta.Value);
            return CustomResponse(movimentacoes);
        }

        #region Métodos Privados
        private async Task<Guid?> GetIdConta() =>
         (await _contaService.GetAsync(x => x.IdCliente == _userService.GetId())).FirstOrDefault()?.Id;
        #endregion
    }
}

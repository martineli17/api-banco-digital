using Api.Controllers.Base;
using Api.Core.Configuracoes.Seguranca;
using Api.Core.Constantes;
using Api.Core.DTO.Autenticacao;
using Crosscuting.Notificacao;
using Dominio.Entidades;
using Dominio.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route(Urls.Version01 + "autenticacao")]
    public class AutenticacaoController : BaseController
    {
        private readonly TokenProviderService _token;
        private readonly IClienteService _clienteService;
        public AutenticacaoController(BaseControllerInjector injector, TokenProviderService token, IClienteService clienteService) 
            : base(injector)
        {
            _token = token;
            _clienteService = clienteService;
        }
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 400)]
        [ProducesResponseType(typeof(IEnumerable<MensagemNotificacao>), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<string>> Loin([FromBody] LoginRequest login)
        {
            var entidade = (await _clienteService.GetAsync(x => x.Cpf == login.Cpf)).FirstOrDefault();
            if(entidade is null)
                return CustomResponse<string>(null, 404, 404);
            var claims = new Dictionary<string, string>();
            claims.Add("Id", entidade.Id.ToString());
            var token = _token.GenerateToken(claims);
            return CustomResponse(token);
        }
    }
}

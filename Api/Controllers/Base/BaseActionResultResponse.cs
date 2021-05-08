using Crosscuting.Notificacao;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers.Base
{
    public class BaseActionResultResponse<TResponse>
    {
        public TResponse Dados { get; set; }
        public IReadOnlyList<MensagemNotificacao> Notificacoes { get; set; }

        public BaseActionResultResponse(TResponse dados, IEnumerable<MensagemNotificacao> notificacoes = null)
        {
            Dados = dados;
            Notificacoes = notificacoes.ToList();
        }
    }
}

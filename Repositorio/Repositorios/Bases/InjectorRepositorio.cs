using Crosscuting.Notificacao;
using Repositorio.Contexto;

namespace Repositorio.Repositorios.Bases
{
    public class InjectorRepositorio
    {
        public readonly Contexto.ContextoBanco Context;
        public readonly INotificador Notificador;

        public InjectorRepositorio(Contexto.ContextoBanco context, INotificador notificador)
        {
            Context = context;
            Notificador = notificador;
        }
    }
}

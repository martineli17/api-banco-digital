using Crosscuting.Notificacao;
using Repositorio.Contexto;

namespace Repositorio.Repositorios.Bases
{
    public class InjectorRepositorio
    {
        public readonly Context Context;
        public readonly INotificador Notificador;

        public InjectorRepositorio(Context context, INotificador notificador)
        {
            Context = context;
            Notificador = notificador;
        }
    }
}

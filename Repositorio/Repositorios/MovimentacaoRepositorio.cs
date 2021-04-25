using Dominio.Entidades;
using Repositorio.Repositorios.Bases;

namespace Repositorio.Repositorios
{
    public class MovimentacaoRepositorio : BaseRepositorio<Movimentacao>
    {
        public MovimentacaoRepositorio(InjectorRepositorio injector) : base(injector)
        {
        }
    }
}

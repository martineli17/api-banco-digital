using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Repositorio.Repositorios.Bases;

namespace Repositorio.Repositorios
{
    public class MovimentacaoRepositorio : BaseRepositorio<Movimentacao>, IMovimentacaoRepositorio
    {
        public MovimentacaoRepositorio(InjectorRepositorio injector) : base(injector)
        {
        }
    }
}

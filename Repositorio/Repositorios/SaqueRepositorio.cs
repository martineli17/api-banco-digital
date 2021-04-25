using Dominio.Entidades;
using Repositorio.Repositorios.Bases;

namespace Repositorio.Repositorios
{
    public class SaqueRepositorio : BaseRepositorio<Saque>
    {
        public SaqueRepositorio(InjectorRepositorio injector) : base(injector)
        {
        }
    }
}

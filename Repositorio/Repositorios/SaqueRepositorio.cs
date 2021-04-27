using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Repositorio.Repositorios.Bases;

namespace Repositorio.Repositorios
{
    public class SaqueRepositorio : BaseRepositorio<Saque>, ISaqueRepositorio
    {
        public SaqueRepositorio(InjectorRepositorio injector) : base(injector)
        {
        }
    }
}

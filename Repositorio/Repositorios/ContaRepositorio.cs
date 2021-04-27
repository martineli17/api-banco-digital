using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Repositorio.Repositorios.Bases;

namespace Repositorio.Repositorios
{
    public class ContaRepositorio : BaseRepositorio<Conta>, IContaRepositorio
    {
        public ContaRepositorio(InjectorRepositorio injector) : base(injector)
        {
        }
    }
}

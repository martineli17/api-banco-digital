using Dominio.Entidades;
using Repositorio.Repositorios.Bases;

namespace Repositorio.Repositorios
{
    public class DepositoRepositorio : BaseRepositorio<Deposito>
    {
        public DepositoRepositorio(InjectorRepositorio injector) : base(injector)
        {
        }
    }
}

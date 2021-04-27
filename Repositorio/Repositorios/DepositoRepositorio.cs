using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Repositorio.Repositorios.Bases;

namespace Repositorio.Repositorios
{
    public class DepositoRepositorio : BaseRepositorio<Deposito>, IDepositoRepositorio
    {
        public DepositoRepositorio(InjectorRepositorio injector) : base(injector)
        {
        }
    }
}

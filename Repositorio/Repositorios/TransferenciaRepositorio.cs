using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Repositorio.Repositorios.Bases;

namespace Repositorio.Repositorios
{
    public class TransferenciaRepositorio : BaseRepositorio<Transferencia>, ITransferenciaRepositorio
    {
        public TransferenciaRepositorio(InjectorRepositorio injector) : base(injector)
        {
        }
    }
}

using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Repositorio.Repositorios.Bases;

namespace Repositorio.Repositorios
{
    public class AgenciaRepositorio : BaseRepositorio<Agencia>, IAgenciaRepositorio
    {
        public AgenciaRepositorio(InjectorRepositorio injector) : base(injector)
        {
        }
    }
}

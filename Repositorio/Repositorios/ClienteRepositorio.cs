using Dominio.Entidades;
using Repositorio.Repositorios.Bases;

namespace Repositorio.Repositorios
{
    public class ClienteRepositorio : BaseRepositorio<Cliente>
    {
        public ClienteRepositorio(InjectorRepositorio injector) : base(injector)
        {
        }
    }
}

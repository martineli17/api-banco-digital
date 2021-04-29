using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Repositorio.Repositorios.Bases;

namespace Repositorio.Repositorios
{
    public class CartaoRepositorio : BaseRepositorio<Cartao>, ICartaoRepositorio
    {
        public CartaoRepositorio(InjectorRepositorio injector) : base(injector)
        {
        }
    }
}

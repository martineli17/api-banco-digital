using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Service;
using Service.Services.Bases;
using Service.Services.ServicesBase;

namespace Service.Services
{
    public class MovimentacaoService : BaseService<Movimentacao>, IMovimentacaoService
    {
        public MovimentacaoService(IMovimentacaoRepositorio repositorio, InjectorServiceBase injector) 
            : base(repositorio, injector)
        {
        }
    }
}

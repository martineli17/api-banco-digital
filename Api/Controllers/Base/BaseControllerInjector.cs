using AutoMapper;
using Crosscuting.Notificacao;

namespace Api.Controllers.Base
{
    public class BaseControllerInjector
    {
        public readonly INotificador Notificador;
        public readonly IMapper Mapper;

        public BaseControllerInjector(INotificador notificador, IMapper mapper)
        {
            Notificador = notificador;
            Mapper = mapper;
        }
    }
}

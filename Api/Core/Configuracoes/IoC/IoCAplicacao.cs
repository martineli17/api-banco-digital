using Api.Controllers.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Core.Configuracoes.IoC
{
    public static class IoCAplicacao
    {
        public static IServiceCollection AddIoCAplicacao(this IServiceCollection services)
        {
            services.AddScoped<BaseControllerInjector>();
            return services;
        }
    }
}

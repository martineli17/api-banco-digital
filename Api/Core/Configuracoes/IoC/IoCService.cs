using Crosscuting.Notificacao;
using Dominio.Interfaces.Service;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using Service.Services.ServicesBase;

namespace Api.Core.Configuracoes.IoC
{
    public static class IoCService
    {
        public static IServiceCollection AddIoCService(this IServiceCollection services)
        {
            services.AddScoped<InjectorServiceBase>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IClienteService, ClienteService>();
            return services;
        }
    }
}

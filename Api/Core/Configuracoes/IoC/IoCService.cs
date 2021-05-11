using Crosscuting.Notificacao;
using Dominio.Interfaces.Service;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using Service.Services.ServicesBase;
using System;

namespace Api.Core.Configuracoes.IoC
{
    public static class IoCService
    {
        public static IServiceCollection AddIoCService(this IServiceCollection services)
        {
            services.AddScoped<InjectorServiceBase>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ICartaoService, CartaoService>();
            services.AddScoped<IContaService, ContaService>();
            services.AddScoped<ISaqueService, SaqueService>()
                    .AddScoped(x => new Lazy<ISaqueService>(x.GetService<ISaqueService>()));
            services.AddScoped<IDepositoService, DepositoService>()
                    .AddScoped(x => new Lazy<IDepositoService>(x.GetService<IDepositoService>()));
            services.AddScoped<ITransferenciaService, TransferenciaService>()
                    .AddScoped(x => new Lazy<ITransferenciaService>(x.GetService<ITransferenciaService>()));
            services.AddScoped<IMovimentacaoService, MovimentacaoService>()
                    .AddScoped(x => new Lazy<IMovimentacaoService>(x.GetService<IMovimentacaoService>()));
            return services; 
        }
    }
}

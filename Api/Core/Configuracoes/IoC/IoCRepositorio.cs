using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Repositorio.Bases;
using Microsoft.Extensions.DependencyInjection;
using Repositorio.Repositorios;
using Repositorio.Repositorios.Bases;
using Repositorio.UnitOfWork;

namespace Api.Core.Configuracoes.IoC
{
    public static class IoCRepositorio
    {
        public static IServiceCollection AddIoCRepositorio(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<InjectorRepositorio>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<ICartaoRepositorio, CartaoRepositorio>();
            services.AddScoped<IContaRepositorio, ContaRepositorio>();
            return services;
        }
    }
}

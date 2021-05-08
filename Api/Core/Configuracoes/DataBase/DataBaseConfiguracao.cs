using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositorio.Contexto;

namespace Api.Core.Configuracoes.DataBase
{
    public static class DataBaseConfiguracao
    {
        public static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ContextoBanco>();
            services.AddDbContextPool<ContextoBanco>(options => options
                                                .UseSqlServer(configuration.GetConnectionString("BancoDigital"))
                                                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            return services;
        }
    }
}

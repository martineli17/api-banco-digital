using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using System.Linq;

namespace Api.Core.Configuracoes.OData
{
    public static class ODataConfiguracao
    {
        public static IServiceCollection AddODataCustom(this IServiceCollection services)
        {
            services.AddODataQueryFilter();
            services.AddOData();
            services.AddMvcCore(options =>
            {
                foreach (var outputFormatter in options.OutputFormatters.OfType<OutputFormatter>().Where(x => x.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }

                foreach (var inputFormatter in options.InputFormatters.OfType<InputFormatter>().Where(x => x.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });
            return services;
        }

        public static void UseODataCustom(IEndpointRouteBuilder endpoints)
        {
            endpoints.EnableDependencyInjection();
            endpoints.Expand().Select().Count().OrderBy().Filter().MaxTop(10000);
        }
    }
}

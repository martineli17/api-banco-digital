using Api.Controllers.Base;
using Api.Core.Configuracoes.Seguranca;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Api.Core.Configuracoes.IoC
{
    public static class IoCAplicacao
    {
        public static IServiceCollection AddIoCAplicacao(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<BaseControllerInjector>();
            services.AddSingleton<TokenProviderService>();
            services.AddAuthentication
               (JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,

                       ValidIssuer = Configuration["AppSettings:Issuer"],
                       ValidAudience = Configuration["AppSettings:Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["AppSettings:SecretKey"]))
                   };
               });
            return services;
        }
    }
}

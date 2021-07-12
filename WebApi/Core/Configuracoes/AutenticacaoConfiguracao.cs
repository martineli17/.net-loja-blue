using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using NetDevPack.Identity.Jwt;
using Aplicacao.Objetos;

namespace WebApi.Core.Configuracoes
{
    public static class AutenticacaoConfiguracao
    {
        public static IServiceCollection AddAutenticacao(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.AddSingleton(configuration.GetSection("AppSettings").Get<AppSettings>());
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        var authentication = configuration.GetSection("AppSettings");
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidIssuer = authentication["Issuer"],
                            ValidAudience = authentication["Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authentication["SecretKey"])),
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                        };
                    });
            return services;
        }
    }
}

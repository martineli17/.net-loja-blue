using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositorio.Contexto;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Newtonsoft;

namespace WebApi.Core.Configuracoes
{
    public static class DataBaseConfiguracao
    {
        public static IApplicationBuilder UseConfiguracaoEntity(this IApplicationBuilder app, ContextoEntity contextEntity)
        {
            contextEntity.Database.Migrate();
            return app;
        }
        public static IServiceCollection AddConfiguracaoEntity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextoEntity>(options => options
                                                 .EnableSensitiveDataLogging().EnableDetailedErrors()
                                                 .UseSqlServer(configuration.GetConnectionString("SqlServer"), 
                                                                b => b.MigrationsAssembly("Repositorio"))
                                                 .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            return services;
        }

        public static IServiceCollection AddRedisConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var redisConfiguration = configuration.GetSection("RedisSettings").Get<RedisConfiguration>();
            services.AddStackExchangeRedisExtensions<NewtonsoftSerializer>(redisConfiguration);
            return services;
        }
    }
}

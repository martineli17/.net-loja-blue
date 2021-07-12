using Aplicacao.Handlers.Base;
using Cache.Setup;
using Core.Base;
using Crosscuting.Notificacao;
using Dominio.Contratos.Repositorios;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositorio.Contexto;
using Repositorio.Repositorios;
using Repositorio.Repositorios.Base;
using Servico.Handlers;
using Servico.Handlers.Base;

namespace WebApi.Core.Configuracoes
{
    public static class InjecaoDependenciaConfiguracao
    {
        public static IServiceCollection AddInjecaoDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            #region Crosscuting
            services.AddScoped<INotificador, Notificador>();
            #endregion

            #region Repositorio
            services.AddScoped<BaseRepositoryInjector>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ContextoEntity>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICompraRepository, CompraRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICarrinhoRepository, CarrinhoRepository>();
            #endregion

            #region Core
            services.AddScoped<IMediatorCustom, MediatorCustom>();
            #endregion

            #region Services
            services.AddScoped<HandlerInjector>();
            #endregion

            #region Aplicacao
            services.AddScoped<BaseAplicacaoHandlerInjector>();
            services.AddScoped<ICacheService, CacheService>();
            #endregion

            #region MediatR
            services.AddMediatR(typeof(InjecaoDependenciaConfiguracao).Assembly);
            services.AddMediatR(typeof(BaseRepositoryInjector).Assembly);
            services.AddMediatR(typeof(CompraHandler).Assembly);
            services.AddMediatR(typeof(BaseAplicacaoHandlerInjector).Assembly);
            #endregion

            #region Mapper
            services.AddAutoMapper(typeof(InjecaoDependenciaConfiguracao).Assembly);
            services.AddAutoMapper(typeof(BaseRepositoryInjector).Assembly);
            services.AddAutoMapper(typeof(CompraHandler).Assembly);
            services.AddAutoMapper(typeof(BaseAplicacaoHandlerInjector).Assembly);
            #endregion

            #region Integracao
            #endregion

            return services;
        }
    }
}

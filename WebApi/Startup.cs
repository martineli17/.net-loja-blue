using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Repositorio.Contexto;
using WebApi.Core.Configuracoes;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfiguracaoEntity(Configuration);
            services.AddRedisConfiguration(Configuration);
            services.AddJsonCofig();
            services.AddCorsCustom();
            services.AddControllers();
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Loja API", Version = "v1" }));
            services.AddInjecaoDependencias(Configuration);
            services.AddInjecaoDependencias(Configuration);
            services.AddAutenticacao(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ContextoEntity contextoEntity)
        {
            app.UseStaticFiles();
            app.UseConfiguracaoEntity(contextoEntity);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Loja API - Version 1.0"));
            app.UseMiddleware<ExceptionMiddlware>();
            app.UseCors("CorsOptions");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

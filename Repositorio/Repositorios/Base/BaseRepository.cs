using Core.Objetos;
using Crosscuting.Notificacao;
using Dominio.Contratos.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositorio.Repositorios.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T>,
                                            IBaseAddRepository<T>,
                                            IBaseAtualizarRepository<T>,
                                            IBaseRemoverRepository<T> 
                                            where T : Dominio.Entidades.Entity
    {
        protected BaseRepositoryInjector Injector;


        public BaseRepository(BaseRepositoryInjector injector)
        {
            Injector = injector;
        }
        public IUnitOfWork UnitOfWork => Injector.UnitOfWork;

        public virtual async Task AddAsync(T entidade)
        {
            if (!entidade.IsValido)
                throw new ArgumentException("Entidade inválida");
            await Injector.Context.Set<T>().AddAsync(entidade);
        }

        public virtual async Task RemoverAsync(Guid id)
        {
            var entidade = await BuscarPorIdAsync(id);
            if (entidade is null)
            {
                Injector.Notificador.Add(MensagensValidador.NotFound, EnumTipoMensagem.Warning);
                return;
            }
            Injector.Context.Set<T>().Remove(entidade);
        }

        public virtual async Task AtualizarAsync(T entidade)
        {
            
            if (!entidade.IsValido)
                throw new ArgumentException("Entidade inválida");

            if (!await ExisteAsync(x => x.Id == entidade.Id))
            {
                Injector.Notificador.Add(MensagensValidador.NotFound, EnumTipoMensagem.Warning);
                return;
            }

            Injector.Context.Set<T>().Update(entidade);
        }

        public virtual async Task AtualizarPropsAsync(T entidade, params string[] propriedades)
        {
            if (propriedades is null || !propriedades.Any())
            {
                await AtualizarAsync(entidade);
                return;
            }

            if (!entidade.IsValido)
                throw new ArgumentException("Entidade inválida");

            var entityEntry = Injector.Context.Entry(entidade);

            foreach (var propriedade in propriedades)
                entityEntry.Property(propriedade).IsModified = true;
        }

        public virtual Task<IQueryable<T>> BuscarAsync()
        {
            return Task.FromResult(Injector.Context.Set<T>().AsNoTracking());
        }

        public virtual Task<IQueryable<T>> BuscarAsync(Expression<Func<T, bool>> filter, params string[] includes)
        {
            var query = Injector.Context.Set<T>().AsQueryable();

            if (includes is not null)
                foreach (var include in includes)
                    query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            return Task.FromResult(query.AsNoTracking());
        }

        public virtual async Task<T> BuscarPorIdAsync(Guid id, params string[] includes)
        {
            var query = Injector.Context.Set<T>().AsQueryable();

            if (includes is not null)
                foreach (var include in includes)
                    query = query.Include(include);

            var entidade = await query.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (entidade is null)
                Injector.Notificador.Add(MensagensValidador.NotFound, EnumTipoMensagem.Warning);

            return entidade;
        }

        public virtual async Task<bool> ExisteAsync(Expression<Func<T, bool>> filter)
        {
            return await Injector.Context.Set<T>().AnyAsync(filter);
        }
    }
}

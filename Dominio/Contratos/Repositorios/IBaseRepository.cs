using Dominio.Entidades;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dominio.Contratos.Repositorios
{
    public interface IBaseRepository<T> where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }
        Task<IQueryable<T>> BuscarAsync();
        Task<IQueryable<T>> BuscarAsync(Expression<Func<T, bool>> filter, params string[] includes);
        Task<T> BuscarPorIdAsync(Guid id, params string[] includes);
        Task<bool> ExisteAsync(Expression<Func<T, bool>> filter);
    }

    public interface IBaseRemoverRepository<T> where T : Entity
    {
        Task RemoverAsync(Guid id);
    }

    public interface IBaseAddRepository<T> where T : Entity
    {
        Task AddAsync(T entidade);
    }

    public interface IBaseAtualizarRepository<T> where T : Entity
    {
        Task AtualizarAsync(T entidade);
        Task AtualizarPropsAsync(T entidade, params string[] propriedades);
    }
}

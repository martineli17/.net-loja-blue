using Dominio.Entidades;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dominio.Contratos.Repositorios
{
    public interface ICompraRepository : IBaseRepository<Compra>, 
                                        IBaseAddRepository<Compra>
    {
        Task<IQueryable<Compra>> BuscarDadosCompletosAsync(Expression<Func<Compra, bool>> filter);
    }
}

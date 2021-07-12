using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Repositorios.Base;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositorio.Repositorios
{
    public class CompraRepository : BaseRepository<Compra>, ICompraRepository
    {
        public CompraRepository(BaseRepositoryInjector injector) : base(injector)
        {
        }

        public override async Task AddAsync(Compra entidade)
        {
            foreach (var produto in entidade.Produtos.Select(x => x.Produto))
                Injector.Context.Entry(entidade.Produtos.First(x => x.IdProduto == produto.Id).Produto).State = EntityState.Unchanged;
            await base.AddAsync(entidade);
        }

        public Task<IQueryable<Compra>> BuscarDadosCompletosAsync(Expression<Func<Compra, bool>> filter)
        {
            var query = Injector.Context.Compra.Where(filter).Include(x => x.Produtos).ThenInclude(x => x.Produto);
            return Task.FromResult(query.AsNoTracking());
        }
    }
}

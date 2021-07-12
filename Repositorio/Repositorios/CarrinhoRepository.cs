using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositorio.Repositorios
{
    public class CarrinhoRepository : BaseRepository<Carrinho>, ICarrinhoRepository
    {
        public CarrinhoRepository(BaseRepositoryInjector injector) : base(injector)
        {
        }

        public override async Task AddAsync(Carrinho entidade)
        {
            foreach (var produto in entidade.Produtos.Select(x => x.Produto))
                Injector.Context.Entry(entidade.Produtos.First(x => x.IdProduto == produto.Id).Produto).State = EntityState.Unchanged;
            await base.AddAsync(entidade);
        }

        public override async Task AtualizarAsync(Carrinho entidade)
        {
            foreach (var produto in entidade.Produtos.Select(x => x.Produto))
                Injector.Context.Entry(entidade.Produtos.First(x => x.IdProduto == produto.Id).Produto).State = EntityState.Unchanged;
            await base.AtualizarAsync(entidade);
        }

        public Task RemoverProdutosAsync(IEnumerable<CarrinhoProduto> carrinhoProdutos)
        {
            Injector.Context.CarrinhoProduto.RemoveRange(carrinhoProdutos);
            return Task.CompletedTask;
        }

        public Task AtualizarProdutosAsync(IEnumerable<CarrinhoProduto> carrinhoProdutos)
        {
            foreach (var produto in carrinhoProdutos)
            {
                Injector.Context.Entry(carrinhoProdutos.First(x => x.Id == produto.Id).Produto).State = EntityState.Unchanged;
            }
            Injector.Context.CarrinhoProduto.UpdateRange(carrinhoProdutos);
            return Task.CompletedTask;
        }

        public async Task AdicionarProdutosAsync(IEnumerable<CarrinhoProduto> carrinhoProdutos)
        {
            foreach (var produto in carrinhoProdutos)
            {
                Injector.Context.Entry(carrinhoProdutos.First(x => x.Id == produto.Id).Produto).State = EntityState.Unchanged;
                Injector.Context.Entry(carrinhoProdutos.First(x => x.Id == produto.Id).Carrinho).State = EntityState.Unchanged;
            }
            await Injector.Context.CarrinhoProduto.AddRangeAsync(carrinhoProdutos);
        }

        public Task<IQueryable<Carrinho>> BuscarDadosCompletosAsync(Expression<Func<Carrinho, bool>> filter)
        {
            var query = Injector.Context.Carrinho.Where(filter).Include(x => x.Produtos).ThenInclude(x => x.Produto);
            return Task.FromResult(query.AsNoTracking());
        }
    }
}

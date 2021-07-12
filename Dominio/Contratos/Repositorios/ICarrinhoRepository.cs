using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dominio.Contratos.Repositorios
{
    public interface ICarrinhoRepository : IBaseRepository<Carrinho>, 
                                        IBaseAddRepository<Carrinho>, 
                                        IBaseRemoverRepository<Carrinho>, 
                                        IBaseAtualizarRepository<Carrinho>
    {
        Task<IQueryable<Carrinho>> BuscarDadosCompletosAsync(Expression<Func<Carrinho, bool>> filter);
        Task RemoverProdutosAsync(IEnumerable<CarrinhoProduto> carrinhoProdutos);
        Task AtualizarProdutosAsync(IEnumerable<CarrinhoProduto> carrinhoProdutos);
        Task AdicionarProdutosAsync(IEnumerable<CarrinhoProduto> carrinhoProdutos);
    }
}

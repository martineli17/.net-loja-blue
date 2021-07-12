using Dominio.Entidades;

namespace Dominio.Contratos.Repositorios
{
    public interface IProdutoRepository : IBaseRepository<Produto>, 
                                        IBaseAddRepository<Produto>, 
                                        IBaseAtualizarRepository<Produto>
    {
    }
}

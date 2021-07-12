using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using Repositorio.Repositorios.Base;

namespace Repositorio.Repositorios
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(BaseRepositoryInjector injector) : base(injector)
        {
        }
    }
}

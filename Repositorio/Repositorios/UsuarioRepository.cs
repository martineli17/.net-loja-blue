using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using Repositorio.Repositorios.Base;

namespace Repositorio.Repositorios
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(BaseRepositoryInjector injector) : base(injector)
        {
        }
    }
}

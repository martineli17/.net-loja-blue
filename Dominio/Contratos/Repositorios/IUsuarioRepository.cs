using Dominio.Entidades;

namespace Dominio.Contratos.Repositorios
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>,
                                        IBaseAddRepository<Usuario>,
                                        IBaseAtualizarRepository<Usuario>
    {
    }
}

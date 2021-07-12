using System.Threading.Tasks;

namespace Dominio.Contratos.Repositorios
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}

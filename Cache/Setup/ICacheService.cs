using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cache.Setup
{
    public interface ICacheService
    {
        Task AddAsync<TObject>(string chave, TObject objeto, int minutos = 60, string tag = null);
        Task RemoverAsync(string chave);
        Task<IEnumerable<TResponse>> BuscarAsync<TResponse>(string chave);
        Task<IEnumerable<TResponse>> BuscarPorTagAsync<TResponse>(string tag);
    }
}

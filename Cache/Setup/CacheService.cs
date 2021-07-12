using StackExchange.Redis.Extensions.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cache.Setup
{
    public class CacheService : ICacheService
    {
        private readonly IRedisCacheClient _cache;

        public CacheService(IRedisCacheClient cache)
        {
            _cache = cache;
        }

        public async Task AddAsync<TObject>(string chave, TObject objeto, int minutos = 60, string tag = null)
        {
            var tags = new HashSet<string>();
            tags.Add(tag);
            await _cache
               .GetDbFromConfiguration()
               .AddAsync(chave, objeto, TimeSpan.FromMinutes(minutos).Subtract(TimeSpan.FromMinutes(2)), tags: tags);
        }

        public async Task<IEnumerable<TResponse>> BuscarAsync<TResponse>(string chave) =>
           await _cache.GetDbFromConfiguration().GetAsync<IEnumerable<TResponse>>(chave) 
                ?? default(IEnumerable<TResponse>);

        public async Task<IEnumerable<TResponse>> BuscarPorTagAsync<TResponse>(string tag) =>
          await _cache.GetDbFromConfiguration().GetByTagAsync<TResponse>(tag)
               ?? default(IEnumerable<TResponse>);

        public async Task RemoverAsync(string chave) => await _cache.GetDbFromConfiguration().RemoveAsync(chave);
    }
}

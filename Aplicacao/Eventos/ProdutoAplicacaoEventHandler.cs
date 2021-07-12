using Aplicacao.Commands.ProdutoCommands;
using Cache.Setup;
using Core.Base;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Eventos
{
    public class ProdutoAplicacaoEventHandler : IBaseEventHandler<ProdutoAdicionadoAplicacaoEvent>
    {
        private readonly ICacheService _cache;

        public ProdutoAplicacaoEventHandler(ICacheService cache)
        {
            _cache = cache;
        }

        public async Task Handle(ProdutoAdicionadoAplicacaoEvent notification, CancellationToken cancellationToken)
        {
            await _cache.AddAsync($"PRODUTO_{notification.Produto.Id}", notification.Produto, 45000, "PRODUTOS");
        }
    }
}

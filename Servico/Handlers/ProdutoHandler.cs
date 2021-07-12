using Core.Base;
using Crosscuting.Notificacao;
using Dominio.Contratos.Commands.ProdutoCommands;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using Servico.Handlers.Base;
using System.Threading;
using System.Threading.Tasks;

namespace Servico.Handlers
{
    public class ProdutoHandler : IBaseRequestHandler<AddProdutoCommand, Produto>
    {
        private readonly HandlerInjector _injector;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoHandler(HandlerInjector injector,
            IProdutoRepository produtoRepository)
        {
            _injector = injector;
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> Handle(AddProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = _injector.Mapper.Map<Produto>(request);
            if (!produto.IsValido)
            {
                _injector.Notificador.AddRange(produto.ErrosValidacao, EnumTipoMensagem.Warning);
                return null;
            }
            if(await _produtoRepository.ExisteAsync(x => x.Nome == request.Nome))
            {
                _injector.Notificador.Add("Produto informado já está cadastrado.", EnumTipoMensagem.Warning);
                return null;
            }
            await _produtoRepository.AddAsync(produto);
            return produto;
        }
    }
}

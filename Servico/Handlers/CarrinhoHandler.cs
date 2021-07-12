using Core.Base;
using Core.Objetos;
using Crosscuting.Notificacao;
using Dominio.Contratos.Commands.CarrinhoCommands;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using Servico.Handlers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Servico.Handlers
{
    public class CarrinhoHandler : IBaseRequestHandler<AddCarrinhoCommand, Carrinho>,
                                IBaseRequestHandler<NovoCarrinhoProdutoCommand, Carrinho>,
                                IBaseRequestHandler<AtualizarCarrinhoCommand, Carrinho>,
                                IBaseRequestHandler<RemoverCarrinhoCommand, bool>,
                                IBaseRequestHandler<RemoverCarrinhoProdutoCommand, bool>
    {
        private readonly HandlerInjector _injector;
        private readonly ICarrinhoRepository _carrinhoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public CarrinhoHandler(HandlerInjector injector,
            ICarrinhoRepository carrinhoRepository,
            IUsuarioRepository usuarioRepository,
            IProdutoRepository produtoRepository)
        {
            _injector = injector;
            _carrinhoRepository = carrinhoRepository;
            _usuarioRepository = usuarioRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<Carrinho> Handle(AddCarrinhoCommand request, CancellationToken cancellationToken)
        {
            var carrinho = _injector.Mapper.Map<Carrinho>(request);
            await DefinirProdutosAsync(carrinho);
            if (!ValidarCarrinho(carrinho)) return null;
            if (!await VerificarUsuarioAsync(request.IdUsuario)) return null;
            if (!await VerificarProdutosAsync(request.Produtos.Select(x => x.IdProduto))) return null;
            await _carrinhoRepository.AddAsync(carrinho);
            return carrinho;
        }

        public async Task<Carrinho> Handle(AtualizarCarrinhoCommand request, CancellationToken cancellationToken)
        {
            var idProdutos = request.Produtos.Select(p => p.Id);
            var carrinho = (await _carrinhoRepository.BuscarDadosCompletosAsync(x => x.IdUsuario == request.IdUsuario)).FirstOrDefault();

            if (carrinho.Produtos.Any(x => !idProdutos.Contains(x.Id)))
            {
                _injector.Notificador.Add(MensagensValidador.NotFoundCustom("Produto"), EnumTipoMensagem.Warning);
                return null;
            }

            foreach (var produto in carrinho.Produtos)
                produto.DefinirQuantidade(request.Produtos.First(x => x.Id == produto.Id).Quantidade);
            carrinho.CalcularValorTotal();

            if (!ValidarCarrinho(carrinho)) return null;
            await _carrinhoRepository.AtualizarProdutosAsync(carrinho.Produtos);
            await _carrinhoRepository.AtualizarPropsAsync(carrinho, nameof(Carrinho.ValorTotal));
            return carrinho;
        }

        public async Task<Carrinho> Handle(NovoCarrinhoProdutoCommand request, CancellationToken cancellationToken)
        {
            var carrinho = (await _carrinhoRepository.BuscarDadosCompletosAsync(x => x.IdUsuario == request.IdUsuario)).FirstOrDefault();
            var produtos = _injector.Mapper.Map<ICollection<CarrinhoProduto>>(request.Produtos);
            if (!ValidarCarrinhoNulo(carrinho)) return null;

            carrinho.AdicionarProdutos(produtos);
            await DefinirProdutosAsync(carrinho);

            if (!ValidarCarrinho(carrinho)) return null;
            await _carrinhoRepository.AdicionarProdutosAsync(carrinho.Produtos.Where(x => request.Produtos.Select(p => p.IdProduto).Contains(x.Id)));
            await _carrinhoRepository.AtualizarPropsAsync(carrinho, nameof(Carrinho.ValorTotal));
            return carrinho;
        }

        public async Task<bool> Handle(RemoverCarrinhoProdutoCommand request, CancellationToken cancellationToken)
        {
            var carrinho = (await _carrinhoRepository.BuscarDadosCompletosAsync(x => x.IdUsuario == request.IdUsuario)).FirstOrDefault();

            if (carrinho is null)
            {
                _injector.Notificador.Add(MensagensValidador.NotFoundCustom("Um ou mais produto"), EnumTipoMensagem.Warning);
                return false;
            }

            await _carrinhoRepository.RemoverProdutosAsync(carrinho.Produtos.Where(x => request.IdCarrinhoProdutos.Contains(x.Id)));
            carrinho.DefinirProdutos(carrinho.Produtos.Where(x => !request.IdCarrinhoProdutos.Contains(x.Id)).ToList());
            await _carrinhoRepository.AtualizarPropsAsync(carrinho, nameof(Carrinho.ValorTotal));
            return true;
        }

        public async Task<bool> Handle(RemoverCarrinhoCommand request, CancellationToken cancellationToken)
        {
            await _carrinhoRepository.RemoverAsync(request.Id);
            return true;
        }

        #region Métodos Privados
        private async Task<bool> VerificarUsuarioAsync(Guid id)
        {
            var usuarioExiste = await _usuarioRepository.ExisteAsync(x => x.Id == id);
            if (!usuarioExiste)
                _injector.Notificador.Add(MensagensValidador.NotFoundCustom("Usuário"));
            return usuarioExiste;
        }

        private async Task<bool> VerificarProdutosAsync(IEnumerable<Guid> ids)
        {
            var produtoExiste = await _produtoRepository.ExisteAsync(x => !ids.Contains(x.Id));
            if (!produtoExiste)
                _injector.Notificador.Add(MensagensValidador.NotFoundCustom("Produto"));
            return produtoExiste;
        }

        private async Task DefinirProdutosAsync(Carrinho carrinho)
        {
            var idsProdutos = carrinho.Produtos.Where(x => x.Produto is null).Select(x => x.IdProduto);
            if (idsProdutos is null || !idsProdutos.Any()) return;
            var produtos = (await _produtoRepository.BuscarAsync(x => idsProdutos.Contains(x.Id))).AsEnumerable();
            if (produtos is null) return;
            carrinho.Produtos.Where(x => x.Produto is null).ToList().ForEach(x =>
            {
                x.DefinirProduto(produtos.FirstOrDefault(p => p.Id == x.IdProduto));
                x.DefinirCarrinho(carrinho);
            });
            carrinho.CalcularValorTotal();
        }

        public bool ValidarCarrinhoNulo(Carrinho carrinho)
        {
            if (carrinho is null)
                _injector.Notificador.Add(MensagensValidador.NotFoundCustom("Carrinho"), EnumTipoMensagem.Warning);
            return carrinho is not null;
        }

        public bool ValidarCarrinho(Carrinho carrinho)
        {
            if (!carrinho.IsValido)
                _injector.Notificador.AddRange(carrinho.ErrosValidacao, EnumTipoMensagem.Warning);
            return carrinho.IsValido;
        }
        #endregion
    }
}

using Core.Base;
using Core.Objetos;
using Crosscuting.Notificacao;
using Dominio.Contratos.Commands.CarrinhoCommands;
using Dominio.Contratos.Commands.CompraCommands;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using Servico.Handlers.Base;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Servico.Handlers
{
    public class CompraHandler : IBaseRequestHandler<AddCompraCommand, Compra>
    {
        private readonly HandlerInjector _injector;
        private readonly ICompraRepository _compraRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICarrinhoRepository _carrinhoRepository;

        public CompraHandler(HandlerInjector injector,
            ICompraRepository compraRepository,
            IUsuarioRepository usuarioRepository,
            ICarrinhoRepository carrinhoRepository)
        {
            _injector = injector;
            _compraRepository = compraRepository;
            _usuarioRepository = usuarioRepository;
            _carrinhoRepository = carrinhoRepository;
        }

        public async Task<Compra> Handle(AddCompraCommand request, CancellationToken cancellationToken)
        {
            var compra = new Compra();
            if (!await ValidarDadosUsuarioAsync(request)) return null;
            
            var carrinho = (await _carrinhoRepository.BuscarDadosCompletosAsync(x => x.IdUsuario == request.IdUsuario)).FirstOrDefault();
            if (!ValidarCarrinho(carrinho)) return null;

            compra.InserirCarrinho(carrinho);
            compra.DefinirUsuario(request.IdUsuario);

            if (!ValidarCompra(compra))  return null;
            await _compraRepository.AddAsync(compra);
            await _injector.Mediator.EnviarComandoAsync(new RemoverCarrinhoCommand { Id = carrinho.Id });
            return compra;
        }

        #region Métodos Privados
        private async Task<bool> ValidarDadosUsuarioAsync(AddCompraCommand request)
        {
            var usuario = await _usuarioRepository.BuscarPorIdAsync(request.IdUsuario);
            if (usuario is not null && usuario.Email == request.Email && usuario.Telefone == request.Telefone)
                return true;
            _injector.Notificador.Add(MensagensValidador.NotFoundCustom("Usuário"));
            return false;
        }

        private bool ValidarCompra(Compra compra)
        {
            if (!compra.IsValido)
                _injector.Notificador.AddRange(compra.ErrosValidacao, EnumTipoMensagem.Warning);
            return compra.IsValido;
        }

        private bool ValidarCarrinho(Carrinho carrinho)
        {
            if (carrinho is null)
            {
                _injector.Notificador.Add(MensagensValidador.NotFoundCustom("Carrinho"), EnumTipoMensagem.Warning);
                return false;
            }
            return true;
        }
        #endregion
    }
}

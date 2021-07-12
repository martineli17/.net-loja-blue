using Aplicacao.Commands.CarrinhoCommands;
using Aplicacao.DTO;
using Aplicacao.Handlers.Base;
using Core.Base;
using Dominio.Contratos.Commands.CarrinhoCommands;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Handlers
{
    public class CarrinhoAplicacaoHandler : IBaseRequestHandler<AddCarrinhoAplicacaoCommand, CarrinhoDTO>,
                                        IBaseRequestHandler<AtualizarCarrinhoAplicacaoCommand, CarrinhoDTO>,
                                        IBaseRequestHandler<NovoCarrinhoProdutoAplicacaoCommand, CarrinhoDTO>,
                                        IBaseRequestHandler<RemoverCarrinhoProdutoAplicacaoCommand, bool>
    {
        private readonly BaseAplicacaoHandlerInjector _injector;
        private readonly ICarrinhoRepository _carrinhoRepository;

        public CarrinhoAplicacaoHandler(BaseAplicacaoHandlerInjector injector,
                                        ICarrinhoRepository carrinhoRepository)
        {
            _injector = injector;
            _carrinhoRepository = carrinhoRepository;
        }

        public async Task<CarrinhoDTO> Handle(AddCarrinhoAplicacaoCommand request, CancellationToken cancellationToken)
        {
            var carrinho = (await _carrinhoRepository.BuscarAsync(x => x.IdUsuario == x.IdUsuario)).FirstOrDefault();
            if(carrinho is not null)
            {
                _injector.Notificador.Add("Já existe um carrinho cadastrado para este usuário");
                return null;
            }
            carrinho = await _injector.Mediator.EnviarComandoAsync(request.Carrinho);
            return ModelarRetorno(carrinho);
        }

        public async Task<bool> Handle(RemoverCarrinhoProdutoAplicacaoCommand request, CancellationToken cancellationToken)
        {
            await _injector.Mediator.EnviarComandoAsync(request.Dados);
            return await _injector.UnitOfWork.CommitAsync();
        }

        public async Task<CarrinhoDTO> Handle(AtualizarCarrinhoAplicacaoCommand request, CancellationToken cancellationToken)
        {
            var carrinho = await _injector.Mediator.EnviarComandoAsync(request.Carrinho);
            return ModelarRetorno(carrinho);
        }

        public async Task<CarrinhoDTO> Handle(NovoCarrinhoProdutoAplicacaoCommand request, CancellationToken cancellationToken)
        {
            var carrinho = await _injector.Mediator.EnviarComandoAsync(request.Carrinho);
            return ModelarRetorno(carrinho);
        }


        #region Métodos Privados

        private CarrinhoDTO ModelarRetorno(Carrinho carrinho)
        {
            if (carrinho is not null)
                if (_injector.UnitOfWork.CommitAsync().GetAwaiter().GetResult())
                    return _injector.Mapper.Map<CarrinhoDTO>(carrinho);
            return null;
        }

       
        #endregion
    }
}

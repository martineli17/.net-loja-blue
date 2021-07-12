using Aplicacao.Commands.CompraCommands;
using Aplicacao.DTO;
using Aplicacao.Handlers.Base;
using Core.Base;
using Dominio.Contratos.Commands.CarrinhoCommands;
using Dominio.Contratos.Queries;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Handlers
{
    public class CompraAplicacaoHandler : IBaseRequestHandler<AddCompraAplicacaoCommand, CompraDTO>
    {
        private readonly BaseAplicacaoHandlerInjector _injector;

        public CompraAplicacaoHandler(BaseAplicacaoHandlerInjector injector)
        {
            _injector = injector;
        }

        public async Task<CompraDTO> Handle(AddCompraAplicacaoCommand request, CancellationToken cancellationToken)
        {
            var compra = await _injector.Mediator.EnviarComandoAsync(request.Dados);
   
            if (compra is not null) 
                if (await _injector.UnitOfWork.CommitAsync()) 
                    return _injector.Mapper.Map<CompraDTO>(compra);
            return  null;
        }
    }
}

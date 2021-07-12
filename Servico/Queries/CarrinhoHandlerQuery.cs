using Core.Base;
using Dominio.Contratos.Queries;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Servico.Queries
{
    public class CarrinhoHandlerQuery : IBaseRequestHandler<CarrinhoQuery, Carrinho>
    {
        private readonly ICarrinhoRepository _carrinhoRepository;

        public CarrinhoHandlerQuery(ICarrinhoRepository carrinhoRepository)
        {
            _carrinhoRepository = carrinhoRepository;
        }

        public async Task<Carrinho> Handle(CarrinhoQuery request, CancellationToken cancellationToken)
        {
            return (await _carrinhoRepository.BuscarDadosCompletosAsync(x => x.IdUsuario == request.IdUsuario)).FirstOrDefault();
        }
    }
}

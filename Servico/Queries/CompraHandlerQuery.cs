using Core.Base;
using Dominio.Contratos.Querys;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Servico.Queries
{
    public class CompraHandlerQuery : IBaseRequestHandler<CompraQuery, IQueryable<Compra>>
    {
        private readonly ICompraRepository _compraRepository;

        public CompraHandlerQuery(ICompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
        }

        public async Task<IQueryable<Compra>> Handle(CompraQuery request, CancellationToken cancellationToken)
        {
            return await _compraRepository.BuscarDadosCompletosAsync(x => x.IdUsuario == request.IdUsuario);
        }
    }
}

using Aplicacao.DTO;
using Core.Base;
using Dominio.Contratos.Commands.CompraCommands;

namespace Aplicacao.Commands.CompraCommands
{
    public class AddCompraAplicacaoCommand : BaseCommand<CompraDTO>
    {
        public AddCompraCommand Dados { get; set; }
    }
}

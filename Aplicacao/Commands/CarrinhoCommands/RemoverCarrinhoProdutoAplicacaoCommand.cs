using Core.Base;
using Dominio.Contratos.Commands.CarrinhoCommands;

namespace Aplicacao.Commands.CarrinhoCommands
{
    public class RemoverCarrinhoProdutoAplicacaoCommand : BaseCommand<bool>
    {
        public RemoverCarrinhoProdutoCommand Dados { get; set; }
    }
}

using Aplicacao.DTO;
using Core.Base;
using Dominio.Contratos.Commands.CarrinhoCommands;

namespace Aplicacao.Commands.CarrinhoCommands
{
    public class NovoCarrinhoProdutoAplicacaoCommand : BaseCommand<CarrinhoDTO>
    {
        public NovoCarrinhoProdutoCommand Carrinho { get; set; }
    }
}

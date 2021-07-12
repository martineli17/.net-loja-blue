using Aplicacao.DTO;
using Core.Base;
using Dominio.Contratos.Commands.CarrinhoCommands;

namespace Aplicacao.Commands.CarrinhoCommands
{
    public class AtualizarCarrinhoAplicacaoCommand : BaseCommand<CarrinhoDTO>
    {
        public AtualizarCarrinhoCommand Carrinho { get; set; }
    }
}

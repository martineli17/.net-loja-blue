using Aplicacao.DTO;
using Core.Base;
using Dominio.Contratos.Commands.CarrinhoCommands;

namespace Aplicacao.Commands.CarrinhoCommands
{
    public class AddCarrinhoAplicacaoCommand : BaseCommand<CarrinhoDTO>
    {
        public AddCarrinhoCommand Carrinho { get; set; }
    }
}

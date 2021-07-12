using System;

namespace Dominio.Contratos.Commands.CarrinhoCommands
{
    public class AddCarrinhoProdutoCommand
    {
        public Guid IdProduto { get; set; }
        public int Quantidade { get; set; }
    }
}

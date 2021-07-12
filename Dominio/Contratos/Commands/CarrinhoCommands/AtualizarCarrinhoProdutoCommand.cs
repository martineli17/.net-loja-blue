using System;

namespace Dominio.Contratos.Commands.CarrinhoCommands
{
    public class AtualizarCarrinhoProdutoCommand
    {
        public Guid Id { get; set; }
        public int Quantidade { get; set; }
    }
}

using Core.Base;
using Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Dominio.Contratos.Commands.CarrinhoCommands
{
    public class AddCarrinhoCommand : BaseCommand<Carrinho>
    {
        public Guid IdUsuario { get; set; }
        public IEnumerable<AddCarrinhoProdutoCommand> Produtos { get; set; }
    }


    public class NovoCarrinhoProdutoCommand : BaseCommand<Carrinho>
    {
        public Guid IdUsuario { get; set; }
        public IEnumerable<AddCarrinhoProdutoCommand> Produtos { get; set; }
    }
}

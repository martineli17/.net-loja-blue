using Core.Base;
using Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Dominio.Contratos.Commands.CarrinhoCommands
{
    public class AtualizarCarrinhoCommand : BaseCommand<Carrinho>
    {
        public Guid IdUsuario { get; set; }
        public IEnumerable<AtualizarCarrinhoProdutoCommand> Produtos { get; set; }
    }
}

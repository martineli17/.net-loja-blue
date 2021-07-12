using Core.Base;
using Dominio.Contratos.Commands.Base;
using System;
using System.Collections.Generic;

namespace Dominio.Contratos.Commands.CarrinhoCommands
{
    public class RemoverCarrinhoProdutoCommand : BaseCommand<bool>
    {
        public Guid IdUsuario { get; set; }
        public IEnumerable<Guid> IdCarrinhoProdutos { get; set; }
    }

    public class RemoverCarrinhoCommand : RemoverCommand
    {
    }
}

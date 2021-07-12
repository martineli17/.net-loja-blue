using Core.Base;
using Dominio.Entidades;

namespace Aplicacao.Commands.ProdutoCommands
{
    public class ProdutoAdicionadoAplicacaoEvent : BaseEvent
    {
        public Produto Produto { get; set; }
    }
}

using Core.Base;
using Dominio.Entidades;

namespace Dominio.Contratos.Commands.ProdutoCommands
{
    public class BaseProdutoCommand : BaseCommand<Produto>
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Imagem { get; set; }
    }
}

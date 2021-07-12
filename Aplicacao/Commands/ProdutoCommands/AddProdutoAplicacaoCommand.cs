using Aplicacao.DTO;
using Core.Base;
using Dominio.Entidades;
using Microsoft.AspNetCore.Http;

namespace Aplicacao.Commands.ProdutoCommands
{
    public class AddProdutoAplicacaoCommand : BaseCommand<ProdutoDTO>
    {
        public IFormFile ImagemFile { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}

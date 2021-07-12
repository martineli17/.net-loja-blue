using System;

namespace Aplicacao.DTO
{
    public class CompraProdutoDTO : BaseDTO
    {
        public Guid IdProduto { get;  set; }
        public Guid IdCompra { get;  set; }
        public int Quantidade { get;  set; }
        public decimal ValorTotal { get;  set; }
        public ProdutoDTO Produto { get; set; }

    }
}

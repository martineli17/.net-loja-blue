using System;

namespace Aplicacao.DTO
{
    public class CarrinhoProdutoDTO : BaseDTO
    {
        public Guid IdProduto { get; set; }
        public Guid IdCarrinho { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
        public ProdutoDTO Produto { get; set; }

    }
}

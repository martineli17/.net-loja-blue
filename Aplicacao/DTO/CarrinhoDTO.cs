using System;
using System.Collections.Generic;

namespace Aplicacao.DTO
{
    public class CarrinhoDTO : BaseDTO
    {
        public Guid IdUsuario { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataAlteracao { get; set; }
        public ICollection<CarrinhoProdutoDTO> Produtos { get; set; }
    }
}

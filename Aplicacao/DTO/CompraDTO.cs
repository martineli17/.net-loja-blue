using System;
using System.Collections.Generic;

namespace Aplicacao.DTO
{
    public class CompraDTO : BaseDTO
    {
        public Guid IdUsuario { get;  set; }
        public ICollection<CompraProdutoDTO> Produtos { get;  set; }
        public decimal ValorTotal { get;  set; }
        public UsuarioDTO Usuario { get;  set; }
    }
}

using Core.Base;
using Dominio.Contratos.Queries.Base;
using Dominio.Entidades;
using System;

namespace Dominio.Contratos.Queries
{
    public class CarrinhoQuery : BaseCommand<Carrinho>, IQuery
    {
        public Guid IdUsuario { get; set; }
    }
}

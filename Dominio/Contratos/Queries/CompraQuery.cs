using Core.Base;
using Dominio.Contratos.Queries.Base;
using Dominio.Entidades;
using System;
using System.Linq;

namespace Dominio.Contratos.Querys
{
    public class CompraQuery : BaseCommand<IQueryable<Compra>>, IQuery
    {
        public Guid IdUsuario { get; set; }
    }
}

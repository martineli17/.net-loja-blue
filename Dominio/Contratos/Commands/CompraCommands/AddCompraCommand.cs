using Core.Base;
using Dominio.Entidades;
using System;

namespace Dominio.Contratos.Commands.CompraCommands
{
    public class AddCompraCommand : BaseCommand<Compra>
    {
        public Guid IdUsuario { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}

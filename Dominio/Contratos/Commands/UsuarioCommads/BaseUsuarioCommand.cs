using Core.Base;
using Dominio.Entidades;

namespace Dominio.Contratos.Commands.UsuarioCommads
{
    public class BaseUsuarioCommand : BaseCommand<Usuario>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}

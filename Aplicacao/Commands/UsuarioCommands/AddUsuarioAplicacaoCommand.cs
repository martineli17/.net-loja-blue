using Aplicacao.DTO;
using Core.Base;
using Dominio.Contratos.Commands.UsuarioCommads;
using Dominio.Entidades;

namespace Aplicacao.Commands.UsuarioCommands
{
    public class AddUsuarioAplicacaoCommand : BaseCommand<UsuarioDTO>
    {
        public AddUsuarioCommand Usuario { get; set; }
    }
}

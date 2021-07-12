using Core.Base;
using Dominio.Entidades;

namespace Aplicacao.Commands.UsuarioCommands
{
    public class LoginUsuarioAplicacaoCommand : BaseCommand<LoginReponseAplicacao>
    {
        public string Email { get; set; }
    }

    public class LoginReponseAplicacao
    {
        public LoginReponseAplicacao(string accessToken, Usuario usuario)
        {
            AccessToken = accessToken;
            Usuario = usuario;
        }

        public string AccessToken { get; set; }
        public Usuario Usuario { get; set; }
    }
}

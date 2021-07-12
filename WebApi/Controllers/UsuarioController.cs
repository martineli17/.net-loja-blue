using Aplicacao.Commands.UsuarioCommands;
using Aplicacao.DTO;
using Crosscuting.Notificacao;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Core.Constantes;

namespace WebApi.Controllers
{
    [Route(RouteApi.BaseUrlApi + "usuario")]
    public class UsuarioController : BaseController
    {
        public UsuarioController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpPost]
        [ProducesResponseType(typeof(Usuario), 201)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Usuario>> Add([FromBody] AddUsuarioAplicacaoCommand request)
        {
            var usuario = await Mediator.EnviarComandoAsync(request);
            return CustomResponse(usuario, 201);
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(UsuarioDTO), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<UsuarioDTO>> Login([FromBody] LoginUsuarioAplicacaoCommand request)
        {
            var login = await Mediator.EnviarComandoAsync(request);
            return CustomResponse(login, login is null ? 404 : 200, login is null ? 404 : 400);
        }
    }
}

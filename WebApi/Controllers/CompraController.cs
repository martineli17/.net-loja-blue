using Aplicacao.Commands.CompraCommands;
using Aplicacao.DTO;
using Crosscuting.Notificacao;
using Dominio.Contratos.Querys;
using Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Core.Constantes;

namespace WebApi.Controllers
{
    [Authorize]
    [Route(RouteApi.BaseUrlApi + "compra")]
    public class CompraController : BaseController
    {
        public CompraController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpPost]
        [ProducesResponseType(typeof(CompraDTO), 201)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CompraDTO>> Add([FromBody] AddCompraAplicacaoCommand request)
        {
            request.Dados.IdUsuario = Guid.Parse(HttpContext.User.GetUserId());
            var carrinho = await Mediator.EnviarComandoAsync(request);
            return CustomResponse(carrinho, 201);
        }

        [HttpGet]
        [ProducesResponseType(typeof(CompraDTO), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CompraDTO>> Get()
        {
            var request = new CompraQuery();
            request.IdUsuario = Guid.Parse(HttpContext.User.GetUserId());
            var compras = Mapper.Map<IEnumerable<CompraDTO>>(await Mediator.EnviarComandoAsync(request));
            return CustomResponse(compras);
        }
    }
}

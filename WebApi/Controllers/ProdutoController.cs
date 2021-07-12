using Aplicacao.Commands.ProdutoCommands;
using Aplicacao.DTO;
using Crosscuting.Notificacao;
using Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Core.Constantes;

namespace WebApi.Controllers
{
    [Authorize]
    [Route(RouteApi.BaseUrlApi + "produto")] 
    public class ProdutoController : BaseController
    {
        public ProdutoController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProdutoDTO), 201)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ProdutoDTO>> Add([FromForm] AddProdutoAplicacaoCommand request)
        {
            var produto = await Mediator.EnviarComandoAsync(request);
            return CustomResponse(produto, 201);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProdutoDTO>), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ProdutoDTO>> Get([FromQuery] ProdutoAplicacaoQuery request)
        {
            var produto = await Mediator.EnviarComandoAsync(request);
            return CustomResponse(produto);
        }
    }
}

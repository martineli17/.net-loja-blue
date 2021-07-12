using Aplicacao.Commands.CarrinhoCommands;
using Aplicacao.DTO;
using Crosscuting.Notificacao;
using Dominio.Contratos.Queries;
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
    [Route(RouteApi.BaseUrlApi + "carrinho")]
    public class CarrinhoController : BaseController
    {
        public CarrinhoController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpPost]
        [ProducesResponseType(typeof(CarrinhoDTO), 201)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CarrinhoDTO>> Add([FromBody] AddCarrinhoAplicacaoCommand request)
        {
            request.Carrinho.IdUsuario = Guid.Parse(HttpContext.User.GetUserId());
            var carrinho = await Mediator.EnviarComandoAsync(request);
            return CustomResponse(carrinho, 201);
        }

        [HttpPost("produto")]
        [ProducesResponseType(typeof(CarrinhoDTO), 201)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CarrinhoDTO>> AddProduto([FromBody] NovoCarrinhoProdutoAplicacaoCommand request)
        {
            request.Carrinho.IdUsuario = Guid.Parse(HttpContext.User.GetUserId());
            var carrinho = await Mediator.EnviarComandoAsync(request);
            return CustomResponse(carrinho, 201);
        }

        [HttpPut("produto")]
        [ProducesResponseType(typeof(CarrinhoDTO), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CarrinhoDTO>> Put([FromBody] AtualizarCarrinhoAplicacaoCommand request)
        {
            request.Carrinho.IdUsuario = Guid.Parse(HttpContext.User.GetUserId());
            var carrinho = await Mediator.EnviarComandoAsync(request);
            return CustomResponse(carrinho);
        }

        [HttpDelete("produto")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<bool>> Delete([FromBody] RemoverCarrinhoProdutoAplicacaoCommand request)
        {
            request.Dados.IdUsuario = Guid.Parse(HttpContext.User.GetUserId());
            var carrinho = await Mediator.EnviarComandoAsync(request);
            return CustomResponse(carrinho);
        }

        [HttpGet]
        [ProducesResponseType(typeof(CarrinhoDTO), 200)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 400)]
        [ProducesResponseType(typeof(IEnumerable<Mensagem>), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CarrinhoDTO>> Get()
        {
            var request = new CarrinhoQuery();
            request.IdUsuario = Guid.Parse(HttpContext.User.GetUserId());
            var carrinho = Mapper.Map<CarrinhoDTO>(await Mediator.EnviarComandoAsync(request));
            return CustomResponse(carrinho, carrinho is null ? 404 : 200);
        }
    }
}

using Aplicacao.Commands.ProdutoCommands;
using Aplicacao.DTO;
using Aplicacao.Handlers.Base;
using Aplicacao.Servicos;
using Cache.Setup;
using Core.Base;
using Dominio.Contratos.Commands.ProdutoCommands;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Handlers
{
    public class ProdutoAplicacaoHandler : IBaseRequestHandler<AddProdutoAplicacaoCommand, ProdutoDTO>,
                                    IBaseRequestHandler<ProdutoAplicacaoQuery, IEnumerable<ProdutoDTO>>
    {
        private readonly BaseAplicacaoHandlerInjector _injector;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICacheService _cache;

        public ProdutoAplicacaoHandler(BaseAplicacaoHandlerInjector injector,
                                IWebHostEnvironment webHostEnvironment, 
                                ICacheService cache)
        {
            _injector = injector;
            _webHostEnvironment = webHostEnvironment;
            _cache = cache;
        }

        public async Task<ProdutoDTO> Handle(AddProdutoAplicacaoCommand request, CancellationToken cancellationToken)
        {
            var command = _injector.Mapper.Map<AddProdutoCommand>(request);
            var path = GerenciadorArquivo.CombinarPath(_webHostEnvironment.WebRootPath, "Imagens");
            command.Imagem = GerenciadorArquivo.CombinarPath(path, request.ImagemFile.FileName);
            var produto = await _injector.Mediator.EnviarComandoAsync(command);
            if (produto is null) return null;
            await GerenciadorArquivo.CriarArquivo(request.ImagemFile.OpenReadStream(), path, request.ImagemFile.FileName);
            if (await _injector.UnitOfWork.CommitAsync())
            {
                await _injector.Mediator.PublicarEventoAsync(new ProdutoAdicionadoAplicacaoEvent { Produto = produto });
                return _injector.Mapper.Map<ProdutoDTO>(produto);
            }
            return null;
        }

        public async Task<IEnumerable<ProdutoDTO>> Handle(ProdutoAplicacaoQuery request, CancellationToken cancellationToken)
        {
            return await _cache.BuscarPorTagAsync<ProdutoDTO>("PRODUTOS");
        }
    }
}

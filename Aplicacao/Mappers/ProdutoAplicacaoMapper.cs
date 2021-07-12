using Aplicacao.Commands.ProdutoCommands;
using Aplicacao.DTO;
using AutoMapper;
using Dominio.Contratos.Commands.ProdutoCommands;
using Dominio.Entidades;

namespace Aplicacao.Mappers
{
    public class ProdutoAplicacaoMapper : Profile
    {
        public ProdutoAplicacaoMapper()
        {
            CreateMap<AddProdutoAplicacaoCommand, AddProdutoCommand>();

            CreateMap<Produto, ProdutoDTO>();
        }
    }
}

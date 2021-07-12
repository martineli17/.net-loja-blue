using Aplicacao.Commands.CompraCommands;
using Aplicacao.DTO;
using AutoMapper;
using Dominio.Contratos.Commands.CompraCommands;
using Dominio.Entidades;

namespace Aplicacao.Mappers
{
    public class CompraAplicacaoMapper : Profile
    {
        public CompraAplicacaoMapper()
        {
            CreateMap<Compra, CompraDTO>();
            CreateMap<CompraProduto, CompraProdutoDTO>();
            CreateMap<AddCompraAplicacaoCommand, AddCompraCommand>();
        }
    }
}

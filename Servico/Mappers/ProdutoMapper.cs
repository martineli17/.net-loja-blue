using AutoMapper;
using Dominio.Contratos.Commands.ProdutoCommands;
using Dominio.Entidades;

namespace Servico.Mappers
{
    public class ProdutoMapper : Profile
    {
        public ProdutoMapper()
        {
            CreateMap<AddProdutoCommand, Produto>()
                .AfterMap((src, dest) => dest.DefinirPreco(src.Preco))
                .AfterMap((src, dest) => dest.Validar());
        }
    }
}

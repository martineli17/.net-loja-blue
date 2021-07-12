using AutoMapper;
using Dominio.Contratos.Commands.CarrinhoCommands;
using Dominio.Entidades;
using System.Collections.Generic;

namespace Servico.Mappers
{
    public class CarrinhoMapper : Profile
    {
        public CarrinhoMapper()
        {
            CreateMap<AddCarrinhoCommand, Carrinho>()
               .AfterMap((src, dest) => dest.DefinirUsuario(src.IdUsuario))
               .AfterMap((src, dest) => dest.Validar());

            CreateMap<AtualizarCarrinhoCommand, Carrinho>()
               .AfterMap((src, dest, context) => dest.DefinirProdutos(context.Mapper.Map<ICollection<CarrinhoProduto>>(src.Produtos)))
               .AfterMap((src, dest) => dest.DefinirUsuario(src.IdUsuario))
               .AfterMap((src, dest) => dest.CalcularValorTotal())
               .AfterMap((src, dest) => dest.Validar());

            CreateMap<AddCarrinhoProdutoCommand, CarrinhoProduto>();

            CreateMap<AtualizarCarrinhoProdutoCommand, CarrinhoProduto>();
        }
    }
}

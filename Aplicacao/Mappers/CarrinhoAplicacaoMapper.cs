using Aplicacao.Commands.CarrinhoCommands;
using Aplicacao.DTO;
using AutoMapper;
using Dominio.Contratos.Commands.CarrinhoCommands;
using Dominio.Entidades;

namespace Aplicacao.Mappers
{
    public class CarrinhoAplicacaoMapper : Profile
    {
        public CarrinhoAplicacaoMapper()
        {
            CreateMap<AddCarrinhoAplicacaoCommand, AtualizarCarrinhoCommand>()
                .ForMember(dest => dest.IdUsuario, options => options.MapFrom(src => src.Carrinho.IdUsuario))
                .ForMember(dest => dest.Produtos, options => options.MapFrom(src => src.Carrinho.Produtos));

            CreateMap<Carrinho, CarrinhoDTO>();
            CreateMap<CarrinhoProduto, CarrinhoProdutoDTO>();
        }
    }
}

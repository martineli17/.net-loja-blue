using Aplicacao.DTO;
using AutoMapper;
using Dominio.Entidades;

namespace Aplicacao.Mappers
{
    public class UsuarioAplicacaoMapper : Profile
    {
        public UsuarioAplicacaoMapper()
        {
            CreateMap<Usuario, UsuarioDTO>();
        }
    }
}

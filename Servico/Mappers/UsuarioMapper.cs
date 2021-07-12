using AutoMapper;
using Dominio.Contratos.Commands.UsuarioCommads;
using Dominio.Entidades;

namespace Servico.Mappers
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<AddUsuarioCommand, Usuario>()
                .AfterMap((src, dest) => dest.Validar());
        }
    }
}

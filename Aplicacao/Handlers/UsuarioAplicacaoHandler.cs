using Aplicacao.Commands.UsuarioCommands;
using Aplicacao.DTO;
using Aplicacao.Handlers.Base;
using Aplicacao.Objetos;
using Core.Base;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using Microsoft.IdentityModel.Tokens;
using NetDevPack.Identity.Jwt;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Handlers
{
    public class UsuarioAplicacaoHandler : IBaseRequestHandler<AddUsuarioAplicacaoCommand, UsuarioDTO>,
                                            IBaseRequestHandler<LoginUsuarioAplicacaoCommand, LoginReponseAplicacao>
    {
        private readonly BaseAplicacaoHandlerInjector _injector;
        private readonly AppSettings _appJwtSettings;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioAplicacaoHandler(BaseAplicacaoHandlerInjector injector,
                                    IUsuarioRepository usuarioRepository,
                                    AppSettings appJwtSettings)
        {
            _injector = injector;
            _usuarioRepository = usuarioRepository;
            _appJwtSettings = appJwtSettings;
        }
        public async Task<UsuarioDTO> Handle(AddUsuarioAplicacaoCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _injector.Mediator.EnviarComandoAsync(request.Usuario);
            if (usuario is null)
                return null;
            if (await _injector.UnitOfWork.CommitAsync())
                return  _injector.Mapper.Map<UsuarioDTO>(usuario);
            return null;
        }

        public async Task<LoginReponseAplicacao> Handle(LoginUsuarioAplicacaoCommand request, CancellationToken cancellationToken)
        {
            var usuario = (await _usuarioRepository.BuscarAsync(x => x.Email == request.Email)).FirstOrDefault();
            if (usuario is null) return null;
            return new LoginReponseAplicacao(GenerateToken(usuario), usuario);
        }

        #region Métodos Privados
        private string GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appJwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("sub", usuario.Id.ToString()),
                }),
                Issuer = _appJwtSettings.Issuer,
                Audience = _appJwtSettings.Audience,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        #endregion
    }
}

using Core.Base;
using Crosscuting.Notificacao;
using Dominio.Contratos.Commands.UsuarioCommads;
using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using Servico.Handlers.Base;
using System.Threading;
using System.Threading.Tasks;

namespace Servico.Handlers
{
    public class UsuarioHandler : IBaseRequestHandler<AddUsuarioCommand, Usuario>
    {
        private readonly HandlerInjector _injector;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioHandler(HandlerInjector injector,
            IUsuarioRepository usuarioRepository)
        {
            _injector = injector;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> Handle(AddUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = _injector.Mapper.Map<Usuario>(request);
            if (!usuario.IsValido)
            {
                _injector.Notificador.AddRange(usuario.ErrosValidacao, EnumTipoMensagem.Warning);
                return null;
            }
            if (await _usuarioRepository.ExisteAsync(x => x.Email == request.Email))
            {
                _injector.Notificador.Add("E-mail informado já está sendo utilizado.");
                return null;
            }
            await _usuarioRepository.AddAsync(usuario);
            return usuario;
        }
    }
}

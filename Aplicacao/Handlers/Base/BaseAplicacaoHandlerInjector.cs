using AutoMapper;
using Core.Base;
using Crosscuting.Notificacao;
using Dominio.Contratos.Repositorios;

namespace Aplicacao.Handlers.Base
{
    public class BaseAplicacaoHandlerInjector
    {
        public readonly IUnitOfWork UnitOfWork;
        public readonly IMediatorCustom Mediator;
        public readonly IMapper Mapper;
        public readonly INotificador Notificador;

        public BaseAplicacaoHandlerInjector(IUnitOfWork unitOfWork,
                                    IMediatorCustom mediator,
                                    IMapper mapper, 
                                    INotificador notificador)
        {
            UnitOfWork = unitOfWork;
            Mediator = mediator;
            Mapper = mapper;
            Notificador = notificador;
        }
    }
}

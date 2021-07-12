using AutoMapper;
using Core.Base;
using Crosscuting.Notificacao;

namespace Servico.Handlers.Base
{
    public class HandlerInjector
    {
        internal readonly IMapper Mapper;
        internal readonly INotificador Notificador;
        internal readonly IMediatorCustom Mediator;

        public HandlerInjector(IMapper mapper,
            INotificador notificador,
            IMediatorCustom mediator)
        {
            Mapper = mapper;
            Notificador = notificador;
            Mediator = mediator;
        }
    }
}

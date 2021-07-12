using MediatR;
using System.Threading.Tasks;

namespace Core.Base
{
    public class MediatorCustom : IMediatorCustom
    {
        private readonly IMediator _mediator;
        public MediatorCustom(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<TReturn> EnviarComandoAsync<TReturn>(BaseCommand<TReturn> command)
        {
            return _mediator.Send(command);
        }

        public Task PublicarEventoAsync(BaseEvent evento)
        {
            return _mediator.Publish(evento);
        }
    }
}

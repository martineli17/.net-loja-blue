using System.Threading.Tasks;

namespace Core.Base
{
    public interface IMediatorCustom
    {
        Task<TReturn> EnviarComandoAsync<TReturn>(BaseCommand<TReturn> command);
        Task PublicarEventoAsync(BaseEvent evento);
    }
}

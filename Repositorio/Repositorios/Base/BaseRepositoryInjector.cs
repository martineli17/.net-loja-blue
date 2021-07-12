using Crosscuting.Notificacao;
using Dominio.Contratos.Repositorios;
using Repositorio.Contexto;

namespace Repositorio.Repositorios.Base
{
    public class BaseRepositoryInjector
    {
        internal ContextoEntity Context;
        internal INotificador Notificador;
        internal IUnitOfWork UnitOfWork;

        public BaseRepositoryInjector(
                    ContextoEntity context,
                    INotificador notificador, 
                    IUnitOfWork unitOfWork)
        {
            Context = context;
            Notificador = notificador;
            UnitOfWork = unitOfWork;
        }
    }
}

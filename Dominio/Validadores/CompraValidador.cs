using Core.Objetos;
using Dominio.Entidades;
using FluentValidation;

namespace Dominio.Validadores
{
    public class CompraValidador : AbstractValidator<Compra>
    {
        public CompraValidador()
        {
            RuleFor(x => x.IdUsuario).NotEmpty().WithMessage(MensagensValidador.NotNullGeneric);
            RuleFor(x => x.Produtos).NotEmpty().WithMessage(MensagensValidador.NotNullGeneric);
            RuleFor(x => x.ValorTotal).GreaterThan(0).WithMessage(MensagensValidador.GreaterThan);
            RuleForEach(x => x.Produtos).SetValidator(new CompraProdutoValidador());
        }
    }
}

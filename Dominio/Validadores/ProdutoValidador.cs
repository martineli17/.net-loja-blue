using Core.Objetos;
using Dominio.Entidades;
using FluentValidation;

namespace Dominio.Validadores
{
    public class ProdutoValidador : AbstractValidator<Produto>
    {
        public ProdutoValidador()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage(MensagensValidador.NotNullGeneric).MaximumLength(50).WithMessage(MensagensValidador.MaxLengthInvalid);
            RuleFor(x => x.Imagem).NotEmpty().WithMessage(MensagensValidador.NotNullGeneric);
            RuleFor(x => x.Preco).GreaterThan(0).WithMessage(MensagensValidador.GreaterThan);
        }
    }
}

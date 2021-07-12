using Core.Objetos;
using Dominio.Entidades;
using FluentValidation;

namespace Dominio.Validadores
{
    public class CarrinhoValidador : AbstractValidator<Carrinho>
    {
        public CarrinhoValidador()
        {
            RuleFor(x => x.IdUsuario).NotEmpty().WithMessage(MensagensValidador.NotNullGeneric);
            RuleFor(x => x.Produtos).NotEmpty().WithMessage(MensagensValidador.NotNullGeneric);
            RuleFor(x => x).Must(x => !x.TemProdutoDuplicado()).WithMessage("Um ou mais dos produtos informados já estão cadastrados no carrinho.");
            RuleFor(x => x.ValorTotal).GreaterThan(0).WithMessage(MensagensValidador.GreaterThan);
            RuleForEach(x => x.Produtos).SetValidator(new CarrinhoProdutoValidador());
        }
    }
}

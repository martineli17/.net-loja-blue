using Core.Objetos;
using Dominio.Entidades;
using FluentValidation;

namespace Dominio.Validadores
{
    public class CarrinhoProdutoValidador : AbstractValidator<CarrinhoProduto>
    {
        public CarrinhoProdutoValidador()
        {
            RuleFor(x => x.Produto).NotEmpty().WithMessage(MensagensValidador.NotFoundCustom("Produto"));
            RuleFor(x => x.IdProduto).NotEmpty().WithMessage(MensagensValidador.NotNullGeneric);
            RuleFor(x => x.IdCarrinho).NotEmpty().WithMessage(MensagensValidador.NotNullGeneric);
            RuleFor(x => x.Quantidade).GreaterThanOrEqualTo(0).WithMessage(MensagensValidador.GreaterOrEqualThan);
            RuleFor(x => x.ValorTotal).GreaterThanOrEqualTo(0).WithMessage(MensagensValidador.GreaterOrEqualThan);
            RuleFor(x => x.Produto).SetValidator(new ProdutoValidador());
        }
    }
}

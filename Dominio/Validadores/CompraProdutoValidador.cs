using Core.Objetos;
using Dominio.Entidades;
using FluentValidation;

namespace Dominio.Validadores
{
    public class CompraProdutoValidador : AbstractValidator<CompraProduto>
    {
        public CompraProdutoValidador()
        {
            RuleFor(x => x.Produto).NotEmpty().WithMessage(MensagensValidador.NotFoundCustom("Produto"));
            RuleFor(x => x.IdProduto).NotEmpty().WithMessage(MensagensValidador.NotNullGeneric);
            RuleFor(x => x.IdCompra).NotEmpty().WithMessage(MensagensValidador.NotNullGeneric);
            RuleFor(x => x.Quantidade).GreaterThan(0).WithMessage(MensagensValidador.GreaterThan);
            RuleFor(x => x.ValorTotal).GreaterThan(0).WithMessage(MensagensValidador.GreaterThan);
            RuleFor(x => x.Produto).SetValidator(new ProdutoValidador());
        }
    }
}

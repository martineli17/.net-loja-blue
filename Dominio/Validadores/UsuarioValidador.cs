using Core.Objetos;
using Dominio.Entidades;
using FluentValidation;

namespace Dominio.Validadores
{
    public class UsuarioValidador : AbstractValidator<Usuario>
    {
        public UsuarioValidador()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage(MensagensValidador.EmailInvalid);
            RuleFor(x => x.Telefone).NotEmpty().WithMessage(MensagensValidador.NotNullGeneric).Length(11).WithMessage(MensagensValidador.LengthInvalid);
            RuleFor(x => x.Nome).NotEmpty().WithMessage(MensagensValidador.NotNullGeneric).MaximumLength(11).WithMessage(MensagensValidador.MaxLengthInvalid);
        }
    }
}

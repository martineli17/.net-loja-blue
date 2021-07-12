using Dominio.Validadores;
using System;

namespace Dominio.Entidades
{
    public class Usuario : Entity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }

        public Usuario()
        {
        }
        public override void Validar()
        {
            base.Validar(new UsuarioValidador(), this);
        }

        public Usuario DefinirNome(string nome)
        {
            Nome = nome;
            Validar();
            return this;
        }

        public Usuario DefinirEmail(string email)
        {
            Email = email;
            Validar();
            return this;
        }

        public Usuario DefinirTelefone(string telefone)
        {
            Telefone = telefone;
            Validar();
            return this;
        }
    }
}

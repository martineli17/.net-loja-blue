using Dominio.Validadores;
using System;

namespace Dominio.Entidades
{
    public class Produto : Entity
    {
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public string Imagem { get; private set; }

        public Produto()
        {

        }
        public override void Validar()
        {
            base.Validar(new ProdutoValidador(), this);
        }

        public Produto DefinirNome(string nome)
        {
            Nome = nome;
            Validar();
            return this;
        }

        public Produto DefinirPreco(decimal preco)
        {
            Preco = preco < 0 ? preco *= -1 : preco;
            Validar();
            return this;
        }

        public Produto DefinirImagem(string imagem)
        {
            Imagem = imagem;
            Validar();
            return this;
        }
    }
}

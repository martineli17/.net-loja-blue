using Dominio.Validadores;
using System;

namespace Dominio.Entidades
{
    public class CarrinhoProduto : Entity
    {
        public Guid IdProduto { get; private set; }
        public Guid IdCarrinho { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorTotal { get; private set; }
        public Carrinho Carrinho { get; private set; }
        public Produto Produto { get; private set; }

        public CarrinhoProduto()
        {

        }

        public override void Validar()
        {
            base.Validar(new CarrinhoProdutoValidador(), this);
        }

        public CarrinhoProduto DefinirQuantidade(int quantidade)
        {
            Quantidade = quantidade;
            CalcularValorTotal();
            return this;
        }

        public decimal CalcularValorTotal()
        {
            ValorTotal = Produto is null ? 0 : Produto.Preco * Quantidade;
            Validar();
            return ValorTotal;
        }

        public CarrinhoProduto DefinirProduto(Guid idProduto)
        {
            IdProduto = idProduto;
            Validar();
            return this;
        }

        public CarrinhoProduto DefinirProduto(Produto produto)
        {
            Produto = produto;
            if (Produto is not null)
                IdProduto = Produto.Id;
            Validar();
            return this;
        }

        public CarrinhoProduto DefinirCarrinho(Carrinho carrinho)
        {
            Carrinho = carrinho;
            if (Carrinho is not null)
                IdCarrinho = Carrinho.Id;
            Validar();
            return this;
        }

    }
}

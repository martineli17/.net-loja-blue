using Dominio.Validadores;
using System;

namespace Dominio.Entidades
{
    public class CompraProduto : Entity
    {
        public Guid IdProduto { get; private set; }
        public Guid IdCompra { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorTotal { get; private set; }
        public Compra Compra { get; private set; }
        public Produto Produto { get; private set; }

        public CompraProduto()
        {
           
        }
        public override void Validar()
        {
            base.Validar(new CompraProdutoValidador(), this);
        }

        public CompraProduto DefinirProduto(Guid idProduto)
        {
            IdProduto = idProduto;
            Validar();
            return this;
        }

        public CompraProduto DefinirProduto(Produto produto)
        {
            Produto = produto;
            if (Produto is not null)
                IdProduto = Produto.Id;
            Validar();
            return this;
        }

        public CompraProduto DefinirCompra(Compra compra)
        {
            Compra = compra;
            IdCompra = Compra.Id;
            Validar();
            return this;
        }

        public CompraProduto DefinirQuantidade(int quantidade)
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
    }
}

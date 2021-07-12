using Dominio.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Entidades
{
    public class Compra : Entity
    {
        public Guid IdUsuario { get; private set; }
        public ICollection<CompraProduto> Produtos { get; private set; }
        public decimal ValorTotal { get; private set; }
        public Usuario Usuario { get; private set; }

        public Compra()
        {

        }
        public override void Validar()
        {
            base.Validar(new CompraValidador(), this);
        }

        public Compra DefinirProdutos(ICollection<CompraProduto> produtos)
        {
            Produtos = produtos;
            CalcularValorTotal();
            return this;
        }

        public Compra DefinirUsuario(Guid idUsuario)
        {
            IdUsuario = idUsuario;
            Validar();
            return this;
        }

        public Compra InserirCarrinho(Carrinho carrinho)
        {
            ICollection<CompraProduto> compraProdutos = new List<CompraProduto>();
            foreach (var produto in carrinho.Produtos)
            {
                var compraProduto = new CompraProduto();
                compraProduto.DefinirProduto(produto.Produto);
                compraProduto.DefinirCompra(this);
                compraProduto.DefinirQuantidade(produto.Quantidade);
                compraProduto.CalcularValorTotal();
                compraProdutos.Add(compraProduto);
            }
            DefinirProdutos(compraProdutos);
            return this;
        }

        public decimal CalcularValorTotal()
        {
            ValorTotal = Produtos is null ? 0 : Produtos.Sum(x => x.ValorTotal);
            Validar();
            return ValorTotal;
        }
    }
}

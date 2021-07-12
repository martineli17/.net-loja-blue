using Dominio.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Entidades
{
    public class Carrinho : Entity
    {
        public Guid IdUsuario { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataAlteracao { get; private set; }
        public Usuario Usuario { get; private set; }
        public ICollection<CarrinhoProduto> Produtos { get; private set; }
        public Carrinho()
        {
            Produtos = new List<CarrinhoProduto>();
            DataAlteracao = DateTime.Now;
        }
        public override void Validar()
        {
            base.Validar(new CarrinhoValidador(), this);
        }

        public Carrinho DefinirProdutos(ICollection<CarrinhoProduto> produtos)
        {
            Produtos = produtos;
            CalcularValorTotal();
            return this;
        }

        public Carrinho AdicionarProdutos(ICollection<CarrinhoProduto> produtos)
        {
            foreach (var produto in produtos)
                Produtos.Add(produto);
            CalcularValorTotal();
            return this;
        }

        public Carrinho DefinirUsuario(Guid idUsuario)
        {
            IdUsuario = idUsuario;
            Validar();
            return this;
        }

        public decimal CalcularValorTotal()
        {
            ValorTotal = Produtos.Sum(x => x.CalcularValorTotal());
            Validar();
            return ValorTotal;
        }

        public bool TemProdutoDuplicado()
        {
            return Produtos.GroupBy(x => x.IdProduto).Any(x => x.Count() > 1);
        }
    }
}

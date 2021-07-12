using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTO");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataCriacao).HasColumnName("DARACRIACAO").IsRequired();
            builder.Property(x => x.Nome).HasColumnName("NOME").HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.Imagem).HasColumnName("IMAGEM").IsRequired();
            builder.Property(x => x.Preco).HasColumnName("PRECO").IsRequired();
            //InserirProdutos(builder);
        }

        //APENAS PARA DEMONSTRAÇÃO
        private void InserirProdutos(EntityTypeBuilder<Produto> builder)
        {
            builder.HasData(new Produto().DefinirImagem(@"televisao.jpg").DefinirNome("Televisão Smart TV - 32'").DefinirPreco(2499.90M));
            builder.HasData(new Produto().DefinirImagem(@"tenis.jpg").DefinirNome("Tênis Adidas").DefinirPreco(150.20M));
            builder.HasData(new Produto().DefinirImagem(@"notebook.jpg").DefinirNome("Notebbok MI Prata").DefinirPreco(2149.30M));
            builder.HasData(new Produto().DefinirImagem(@"camisa.jpg").DefinirNome("Camisa Social Azul").DefinirPreco(89.90M));
            builder.HasData(new Produto().DefinirImagem(@"celular.jpg").DefinirNome("Celular Samsung - Azul").DefinirPreco(1789.00M));
        }
    }
}

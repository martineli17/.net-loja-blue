using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Mappings
{
    public class CarrinhoProdutoMapping : IEntityTypeConfiguration<CarrinhoProduto>
    {
        public void Configure(EntityTypeBuilder<CarrinhoProduto> builder)
        {
            builder.ToTable("CARRINHOPRODUTO");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataCriacao).HasColumnName("DARACRIACAO").IsRequired();
            builder.Property(x => x.IdProduto).HasColumnName("IDPRODUTO").IsRequired();
            builder.Property(x => x.IdCarrinho).HasColumnName("IDCARRINHO").IsRequired();
            builder.Property(x => x.ValorTotal).HasColumnName("VALORTOTAL").IsRequired();
            builder.Property(x => x.Quantidade).HasColumnName("QUANTIDADE").IsRequired();
            builder.HasOne(x => x.Carrinho).WithMany().HasForeignKey(x => x.IdCarrinho).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Produto).WithMany().HasForeignKey(x => x.IdProduto).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

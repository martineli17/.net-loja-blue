using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Mappings
{
    public class CompraProdutoMapping : IEntityTypeConfiguration<CompraProduto>
    {
        public void Configure(EntityTypeBuilder<CompraProduto> builder)
        {
            builder.ToTable("COMPRAPRODUTO");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataCriacao).HasColumnName("DATACRIACAO").IsRequired();
            builder.Property(x => x.IdProduto).HasColumnName("IDPRODUTO").IsRequired();
            builder.Property(x => x.IdCompra).HasColumnName("IDCOMPRA").IsRequired();
            builder.Property(x => x.ValorTotal).HasColumnName("VALORTOTAL").IsRequired();
            builder.Property(x => x.Quantidade).HasColumnName("QUANTIDADE").IsRequired();
            builder.HasOne(x => x.Produto).WithMany().HasForeignKey(x => x.IdProduto).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Compra).WithMany().HasForeignKey(x => x.IdCompra).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Mappings
{
    public class CompraMapping : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            builder.ToTable("COMPRA");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataCriacao).HasColumnName("DATACRIACAO").IsRequired();
            builder.Property(x => x.IdUsuario).HasColumnName("IDUSUARIO").IsRequired();
            builder.Property(x => x.ValorTotal).HasColumnName("VALORTOTAL").IsRequired();
            builder.HasMany(x => x.Produtos).WithOne(x => x.Compra).HasForeignKey(x => x.IdCompra).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Usuario).WithMany().HasForeignKey(x => x.IdUsuario).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

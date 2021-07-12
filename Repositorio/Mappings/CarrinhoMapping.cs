using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Mappings
{
    public class CarrinhoMapping : IEntityTypeConfiguration<Carrinho>
    {
        public void Configure(EntityTypeBuilder<Carrinho> builder)
        {
            builder.ToTable("CARRINHO");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataCriacao).HasColumnName("DARACRIACAO").IsRequired();
            builder.Property(x => x.IdUsuario).HasColumnName("IDUSUARIO").IsRequired();
            builder.Property(x => x.ValorTotal).HasColumnName("VALORTOTAL").IsRequired();
            builder.Property(x => x.DataAlteracao).HasColumnName("DATAALTERACAO").IsRequired();
            builder.HasOne(x => x.Usuario).WithOne().HasForeignKey<Carrinho>(x => x.IdUsuario).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Produtos).WithOne().HasForeignKey(x => x.IdCarrinho).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

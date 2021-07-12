using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataCriacao).HasColumnName("DARACRIACAO").IsRequired();
            builder.Property(x => x.Nome).HasColumnName("NOME").HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnName("TELEFONE").HasColumnType("VARCHAR(15)").IsRequired();
            builder.Property(x => x.Email).HasColumnName("EMAIL").HasColumnType("VARCHAR(100)").IsRequired();
        }
    }
}

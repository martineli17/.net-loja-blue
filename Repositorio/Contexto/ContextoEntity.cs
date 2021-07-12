using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
namespace Repositorio.Contexto
{
    public class ContextoEntity : DbContext
    {
        public ContextoEntity(DbContextOptions<ContextoEntity> options) : base(options)
        {
        }


        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<CompraProduto> CompraProduto { get; set; }
        public DbSet<Carrinho> Carrinho { get; set; }
        public DbSet<CarrinhoProduto> CarrinhoProduto { get; set; }
        public DbSet<Produto> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }
    }
}

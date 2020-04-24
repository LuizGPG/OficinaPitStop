
using Microsoft.EntityFrameworkCore;
using OficinaPitStop.Entities.Produtos;
using OficinaPitStop.Repositories.Models.Produtos;

namespace OficinaPitStop.Repositories
{
    public class OficinaPitStopContext : DbContext
    {
        public OficinaPitStopContext(DbContextOptions<OficinaPitStopContext> options) : base(options)
        {
        }
        
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProdutoModel>(
                entity =>
                {
                    entity
                        .HasKey(e => e.Codigo)
                        .HasName("id");
                });
        }
    }
}
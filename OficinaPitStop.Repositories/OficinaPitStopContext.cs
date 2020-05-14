using Microsoft.EntityFrameworkCore;
using OficinaPitStop.Entities.Produtos;
using OficinaPitStop.Entities.Produtos.Marcas;

namespace OficinaPitStop.Repositories
{
    public class OficinaPitStopContext : DbContext
    {
        public OficinaPitStopContext(DbContextOptions<OficinaPitStopContext> options) : base(options)
        {
        }
        
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Marca> Marca { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            https://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx
            modelBuilder.Entity<Produto>(
                entity =>
                {
                    entity
                        .HasKey(e => e.Codigo)
                        .HasColumn
                });
            
            base.OnModelCreating(modelBuilder);
        }*/
    }
}
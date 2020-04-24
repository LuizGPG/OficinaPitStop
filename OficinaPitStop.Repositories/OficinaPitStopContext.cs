
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

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Produto>(
                entity =>
                {
                    entity
                        .HasKey(e => e.Codigo)
                        .HasName("idlo");
                });
            
            base.OnModelCreating(modelBuilder);
        }*/
    }
}
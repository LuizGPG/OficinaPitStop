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
    }
}
using Microsoft.EntityFrameworkCore;
using OficinaPitStop.Entities.Produtos;

namespace OficinaPitStop.Repositories
{
    public class OficinaPitStopContext : DbContext
    {
        public OficinaPitStopContext(DbContextOptions<OficinaPitStopContext> options) : base(options)
        {
            
        }
        
        public DbSet<Produto> Produtos { get; set; }
    }
}
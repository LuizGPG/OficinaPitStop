using System.Collections.Generic;
using System.Linq;
using OficinaPitStop.Entities.Produtos.Marcas;
using OficinaPitStop.Repositories.Abstractions.Repository.Produtos.Marcas;

namespace OficinaPitStop.Repositories.Repository.Produtos.Marcas
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly OficinaPitStopContext _context;
        
        public MarcaRepository(OficinaPitStopContext context)
        {
            _context = context;
        }
        public IEnumerable<Marca> ObtemTodasAsMarcas()
        {
            return _context.Marca.ToList();
        }

        public Marca ObtemMarcaPorId(int codigoMarca)
        {
            return _context.Marca.Find(codigoMarca);
        }
    }
}
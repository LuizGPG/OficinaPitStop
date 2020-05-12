using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<Marca>> ObterTodos()
        {
            return await _context.Marca.ToListAsync();
        }

        public async Task<Marca> ObterPorId(int codigoMarca)
        {
            return await _context.Marca.FindAsync(codigoMarca);
        }

        public async Task<IEnumerable<Marca>> ObterPorNome(string descricao)
        {
            return await _context.Marca.Where(p => p.Descricao.Contains(descricao)).ToListAsync();
        }

        public async Task<bool> Adiciona(Marca marca)
        {
            _context.Marca.Add(marca);
            _context.SaveChanges();

            return true;
        }

        public async Task<bool> Atualiza(Marca marca)
        {
            _context.Marca.Update(marca);
            _context.SaveChanges();

            return true;
        }

        public async Task<bool> Deleta(Marca marca)
        {
            _context.Marca.Remove(marca);
            _context.SaveChanges();

            return true;
        }
    }
}
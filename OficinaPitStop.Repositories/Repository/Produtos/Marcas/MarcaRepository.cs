using System;
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

        public Marca ObterPorId(int codigoMarca) =>
            _context.Marca.FirstOrDefault(m => m.CodigoMarca == codigoMarca);

        public async Task<IEnumerable<Marca>> ObterPorNome(string descricao)
        {
            return await _context.Marca.Where(p => p.Descricao.Contains(descricao)).ToListAsync();
        }

        public bool Adiciona(Marca marca)
        {
            _context.Marca.Add(marca);
            _context.SaveChanges();

            return true;
        }

        public bool Atualiza(Marca marca)
        {
            DetachLocal(_ => _.CodigoMarca == marca.CodigoMarca);
            _context.Marca.Update(marca);
            _context.SaveChanges();

            return true;
        }

        public bool Deleta(Marca marca)
        {
            DetachLocal(_ => _.CodigoMarca == marca.CodigoMarca);
            _context.Marca.Remove(marca);
            _context.SaveChanges();

            return true;
        }
        
        public void DetachLocal(Func<Marca, bool> predicate)
        {
            var local = _context.Set<Marca>().Local.Where(predicate).FirstOrDefault();
            if (local != null)
                _context.Entry(local).State = EntityState.Detached;
        }
    }
}
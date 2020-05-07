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
        public IEnumerable<Marca> ObterTodos()
        {
            return _context.Marca.ToList();
        }

        public Marca ObterPorId(int codigoMarca)
        {
            return _context.Marca.Find(codigoMarca);
        }

        public IEnumerable<Marca> ObterPorNome(string descricao)
        {
            return _context.Marca.Where(p => p.Descricao.Contains(descricao)).ToList();
        }

        public bool Adiciona(Marca marca)
        {
            _context.Marca.Add(marca);
            _context.SaveChanges();

            return true;
        }

        public bool Atualiza(Marca marca)
        {
            _context.Marca.Update(marca);
            _context.SaveChanges();

            return true;
        }

        public bool Deleta(Marca marca)
        {
            _context.Marca.Remove(marca);
            _context.SaveChanges();

            return true;
        }
    }
}
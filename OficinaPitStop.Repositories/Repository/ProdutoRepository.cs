using System.Collections.Generic;
using System.Linq;
using OficinaPitStop.Entities.Produtos;

namespace OficinaPitStop.Repositories.Repository
{
    public class ProdutoRepository
    {
        private readonly OficinaPitStopContext _context;

        public ProdutoRepository(OficinaPitStopContext context)
        {
            _context = context;
        }

        public IEnumerable<Produto> ObtemTodosProdutos()
        {
            return _context.Produtos.ToList();
        }
    }
}
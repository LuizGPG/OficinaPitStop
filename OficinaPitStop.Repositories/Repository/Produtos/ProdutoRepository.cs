using System.Collections.Generic;
using System.Linq;
using OficinaPitStop.Entities.Produtos;
using OficinaPitStop.Repositories.Abstractions.Repository;

namespace OficinaPitStop.Repositories.Repository.Produtos
{
    public class ProdutoRepository : IProdutoRepository
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
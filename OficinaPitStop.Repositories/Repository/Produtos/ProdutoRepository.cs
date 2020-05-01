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

        public IEnumerable<Produto> ObtemProdutosPorNome(string nomeProduto)
        {
            return _context.Produtos.Where(p => p.Descricao.Contains(nomeProduto)).ToList();
        }

        public IEnumerable<Produto> ObterProdutosPorMarca(string marcaProduto)
        {
            var marcas = _context.Marca.Where(m => m.Descricao.Contains(marcaProduto)).Select(x => x.CodigoMarca);
            return _context.Produtos.Where(p => marcas.Contains(p.CodigoMarca)).ToList();
        }
    }
}
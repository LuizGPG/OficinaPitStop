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

        public IEnumerable<Produto> ObtemTodosProdutos() =>
            _context.Produtos.ToList();

        public IEnumerable<Produto> ObtemProdutosPorNome(string nomeProduto) =>
            _context.Produtos.Where(p => p.Descricao.Contains(nomeProduto)).ToList();

        public IEnumerable<Produto> ObterProdutoPorCodigoMarca(IEnumerable<int> codigosMarcas) =>
            _context.Produtos.Where(p => codigosMarcas.Contains(p.CodigoMarca)).ToList();

        public bool AdicionaProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return true;
        }
    }
}
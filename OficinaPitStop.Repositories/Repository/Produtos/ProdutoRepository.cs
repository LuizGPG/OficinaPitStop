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

        public IEnumerable<Produto> ObterTodos() =>
            _context.Produtos.ToList();

        public IEnumerable<Produto> ObterPorId(int idProduto) =>
            _context.Produtos.Where(p => p.Codigo == idProduto).ToList();

        public IEnumerable<Produto> ObterPorNome(string nomeProduto) =>
            _context.Produtos.Where(p => p.Descricao.Contains(nomeProduto)).ToList();

        public IEnumerable<Produto> ObterPorCodigoMarca(IEnumerable<int> codigosMarcas) =>
            _context.Produtos.Where(p => codigosMarcas.Contains(p.CodigoMarca)).ToList();

        public bool Adiciona(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return true;
        }

        public bool Atualiza(Produto produto)
        {
            //todo fazer partial update
            _context.Produtos.Update(produto);
            _context.SaveChanges();
            return true;
        }

        public bool Deleta(Produto produto)
        {
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            
            return true;
        }
    }
}
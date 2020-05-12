using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Produto>> ObterTodos() =>
            await _context.Produtos.ToListAsync();

        public async Task<IEnumerable<Produto>> ObterPorId(int idProduto) =>
            await _context.Produtos.Where(p => p.Codigo == idProduto).ToListAsync();

        public async Task<IEnumerable<Produto>> ObterPorNome(string nomeProduto) =>
            await _context.Produtos.Where(p => p.Descricao.Contains(nomeProduto)).ToListAsync();

        public async Task<IEnumerable<Produto>> ObterPorCodigoMarca(IEnumerable<int> codigosMarcas) =>
            await _context.Produtos.Where(p => codigosMarcas.Contains(p.CodigoMarca)).ToListAsync();

        public async Task<bool> Adiciona(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return true;
        }

        public async Task<bool> Atualiza(Produto produto)
        {
            //todo fazer partial update
            _context.Produtos.Update(produto);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> Deleta(Produto produto)
        {
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            
            return true;
        }
    }
}
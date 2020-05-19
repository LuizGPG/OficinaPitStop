using System;
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

        public Produto ObterPorId(int idProduto)
        {
            var produto = _context.Produtos.Find(idProduto);
            return produto;
        }

        public async Task<IEnumerable<Produto>> ObterPorNome(string nomeProduto) =>
            await _context.Produtos.Where(p => p.Descricao.Contains(nomeProduto)).ToListAsync();

        public async Task<IEnumerable<Produto>> ObterPorCodigoMarca(IEnumerable<int> codigosMarcas) =>
            await _context.Produtos.Where(p => codigosMarcas.Contains(p.CodigoMarca)).ToListAsync();

        public bool Adiciona(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return true;
        }

        public bool Atualiza(Produto produto)
        {
            DetachLocal(_ => _.Codigo == produto.Codigo);
            _context.Produtos.Update(produto);
            _context.SaveChanges();
            return true;
        }

        public bool Deleta(Produto produto)
        {
            DetachLocal(_ => _.Codigo == produto.Codigo);
            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return true;
        }

        public void DetachLocal(Func<Produto, bool> predicate)
        {
            var local = _context.Set<Produto>().Local.Where(predicate).FirstOrDefault();
            if (local != null)
                _context.Entry(local).State = EntityState.Detached;
        }
    }
}
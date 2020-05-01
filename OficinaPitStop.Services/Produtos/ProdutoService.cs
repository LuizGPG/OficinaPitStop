using System.Collections.Generic;
using System.Linq;
using OficinaPitStop.Entities;
using OficinaPitStop.Entities.Produtos;
using OficinaPitStop.Repositories.Abstractions.Repository;
using OficinaPitStop.Repositories.Abstractions.Repository.Produtos.Marcas;
using OficinaPitStop.Services.Abstractions.Produtos;

namespace OficinaPitStop.Services.Produtos
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMarcaRepository _marcaRepository;

        public ProdutoService(IProdutoRepository produtoRepository, IMarcaRepository marcaRepository)
        {
            _produtoRepository = produtoRepository;
            _marcaRepository = marcaRepository;
        }

        public IEnumerable<Produto> ObterProdutosPorFitlro(FiltrosProduto filtros)
        {
            if (filtros.NomeProduto != default && filtros.NomeMarcaProduto != default)
            {
                var produtos = ObterProdutosPorMarca(filtros.NomeMarcaProduto);
                return produtos.Where(p => p.Descricao.Contains(filtros.NomeProduto)).ToList();
            }

            if (filtros.NomeProduto != default)
                return ObtemProdutosPorNome(filtros.NomeProduto);

            if (filtros.NomeMarcaProduto != default)
                return ObterProdutosPorMarca(filtros.NomeMarcaProduto);

            return ObtemTodosProdutos();
        }

        public IEnumerable<Produto> ObtemTodosProdutos() =>
            _produtoRepository.ObtemTodosProdutos();

        public IEnumerable<Produto> ObtemProdutosPorNome(string nomeProduto) =>
            _produtoRepository.ObtemProdutosPorNome(nomeProduto);

        public IEnumerable<Produto> ObterProdutosPorMarca(string marcaProduto)
        {
            var marcas = _marcaRepository.ObterMarcasPorNome(marcaProduto);
            var listaDeDescricao = marcas.Select(m => m.CodigoMarca);
            
            return _produtoRepository.ObterProdutoPorCodigoMarca(listaDeDescricao);
        }
    }
}
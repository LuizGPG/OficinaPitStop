using System.Collections.Generic;
using System.Linq;
using OficinaPitStop.Entities.Filtros.Produtos;
using OficinaPitStop.Entities.Produtos;
using OficinaPitStop.Repositories.Abstractions.Repository;
using OficinaPitStop.Services.Abstractions.Produtos;
using OficinaPitStop.Services.Abstractions.Produtos.Marcas;

namespace OficinaPitStop.Services.Produtos
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMarcaService _marcaService;

        public ProdutoService(IProdutoRepository produtoRepository, IMarcaService marcaService)
        {
            _produtoRepository = produtoRepository;
            _marcaService = marcaService;
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
            var marcas = _marcaService.ObterMarcasPorNome(marcaProduto);
            var codigosMarcas = marcas.Select(m => m.CodigoMarca);
            
            return _produtoRepository.ObterProdutoPorCodigoMarca(codigosMarcas);
        }

        public bool AdicionaProduto(Produto produto) =>
            _produtoRepository.AdicionaProduto(produto);

        public bool AtualizaProduto(Produto produto) =>
            _produtoRepository.AtualizaProduto(produto);
    }
}
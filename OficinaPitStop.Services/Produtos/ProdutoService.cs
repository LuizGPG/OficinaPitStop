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

        public IEnumerable<Produto> ObterPorFitlro(FiltrosProduto filtros)
        {
            if (filtros.NomeProduto != default && filtros.NomeMarcaProduto != default)
            {
                var produtos = ObterProdutosPorMarca(filtros.NomeMarcaProduto);
                return produtos.Where(p => p.Descricao.Contains(filtros.NomeProduto)).ToList();
            }

            if (filtros.NomeProduto != default)
                return ObterPorNome(filtros.NomeProduto);

            if (filtros.NomeMarcaProduto != default)
                return ObterProdutosPorMarca(filtros.NomeMarcaProduto);

            return ObterTodos();
        }

        public IEnumerable<Produto> ObterTodos() =>
            _produtoRepository.ObterTodos();

        public IEnumerable<Produto> ObterPorNome(string nomeProduto) =>
            _produtoRepository.ObterPorNome(nomeProduto);

        public IEnumerable<Produto> ObterProdutosPorMarca(string marcaProduto)
        {
            var marcas = _marcaService.ObterPorNome(marcaProduto);
            var codigosMarcas = marcas.Select(m => m.CodigoMarca);
            
            return _produtoRepository.ObterPorCodigoMarca(codigosMarcas);
        }

        public bool Adiciona(Produto produto) =>
            _produtoRepository.Adiciona(produto);

        public bool Atualiza(Produto produto) =>
            _produtoRepository.Atualiza(produto);

        public bool Deleta(Produto produto) =>
            _produtoRepository.Deleta(produto);
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OficinaPitStop.Entities.Filtros.Produtos;
using OficinaPitStop.Entities.Produtos;
using OficinaPitStop.Repositories.Abstractions.Repository;
using OficinaPitStop.Services.Abstractions.Produtos;
using OficinaPitStop.Services.Abstractions.Produtos.Marcas;
using OficinaPitStop.Services.Execptions;

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

        public async Task<IEnumerable<Produto>> ObterPorFitlro(FiltrosProduto filtros)
        {
            if (filtros.NomeProduto != default && filtros.NomeMarcaProduto != default)
            {
                var produtos = await ObterProdutosPorMarca(filtros.NomeMarcaProduto);
                return produtos.Where(p => p.Descricao.Contains(filtros.NomeProduto)).ToList();
            }

            if (filtros.NomeProduto != default)
                return await ObterPorNome(filtros.NomeProduto);

            if (filtros.NomeMarcaProduto != default)
                return await ObterProdutosPorMarca(filtros.NomeMarcaProduto);

            return await ObterTodos();
        }

        public async Task<IEnumerable<Produto>> ObterTodos() =>
            await _produtoRepository.ObterTodos();

        public async Task<IEnumerable<Produto>> ObterPorNome(string nomeProduto) =>
            await _produtoRepository.ObterPorNome(nomeProduto);

        public async Task<IEnumerable<Produto>> ObterProdutosPorMarca(string marcaProduto)
        {
            var marcas = await _marcaService.ObterPorNome(marcaProduto);
            var codigosMarcas = marcas.Select(m => m.CodigoMarca);

            return await _produtoRepository.ObterPorCodigoMarca(codigosMarcas);
        }

        public async Task<bool> Adiciona(Produto produto) =>
            await _produtoRepository.Adiciona(produto);

        public async Task<bool> Atualiza(Produto produto)
        {
            if ((await _produtoRepository.ObterPorId(produto.Codigo)) != null)
                return await _produtoRepository.Atualiza(produto);

            throw new NotFoundExepction("Produto não encontrado para atualizar!");
        }

        public async Task<bool> Deleta(Produto produto)
        {
            if ((await _produtoRepository.ObterPorId(produto.Codigo)) != null)
                return await _produtoRepository.Deleta(produto);
            
            throw new NotFoundExepction("Produto não encontrado para deletar!");
        }
    }
}
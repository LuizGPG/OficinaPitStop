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
                return produtos.Where(p => p.Descricao.ToUpper().Contains(filtros.NomeProduto.ToUpper())).ToList();
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
            var codigosMarcas = marcas.Select(m => m.CodigoMarca).ToList();

            return await _produtoRepository.ObterPorCodigoMarca(codigosMarcas);
        }

        public bool Adiciona(Produto produto) =>
            _produtoRepository.Adiciona(produto);

        public bool Atualiza(Produto produto)
        {
            if ((_produtoRepository.ObterPorId(produto.Codigo)) != null)
                return _produtoRepository.Atualiza(produto);

            throw new NotFoundExepction("Produto não encontrado para atualizar!");
        }

        public bool Deleta(Produto produto)
        {
            if ((_produtoRepository.ObterPorId(produto.Codigo)) != null)
                return _produtoRepository.Deleta(produto);
            
            throw new NotFoundExepction("Produto não encontrado para deletar!");
        }
    }
}
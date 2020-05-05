using System.Collections.Generic;
using OficinaPitStop.Entities.Produtos;

namespace OficinaPitStop.Repositories.Abstractions.Repository
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> ObtemTodosProdutos();
        IEnumerable<Produto> ObtemProdutosPorNome(string nomeProduto);
        IEnumerable<Produto> ObterProdutoPorCodigoMarca(IEnumerable<int> codigosMarcas);
        bool AdicionaProduto(Produto produto);
    }
}
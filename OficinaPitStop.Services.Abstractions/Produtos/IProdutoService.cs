using System.Collections.Generic;
using OficinaPitStop.Entities.Produtos;

namespace OficinaPitStop.Services.Abstractions.Produtos
{
    public interface IProdutoService
    {
        IEnumerable<Produto> ObtemTodosProdutos();
        IEnumerable<Produto> ObtemProdutosPorNome(string nomeProduto);
        IEnumerable<Produto> ObterProdutosPorMarca(string marcaProduto);
    }
}
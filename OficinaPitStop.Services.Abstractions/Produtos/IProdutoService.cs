using System.Collections;
using System.Collections.Generic;
using OficinaPitStop.Entities.Filtros.Produtos;
using OficinaPitStop.Entities.Produtos;

namespace OficinaPitStop.Services.Abstractions.Produtos
{
    public interface IProdutoService
    {
        IEnumerable<Produto> ObterProdutosPorFitlro(FiltrosProduto filtros);
        IEnumerable<Produto> ObtemTodosProdutos();
        IEnumerable<Produto> ObtemProdutosPorNome(string nomeProduto);

        bool AdicionaProduto(Produto produto);
        bool AtualizaProduto(Produto produto);
    }
}
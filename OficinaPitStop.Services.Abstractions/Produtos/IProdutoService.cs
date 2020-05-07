using System.Collections.Generic;
using OficinaPitStop.Entities.Filtros.Produtos;
using OficinaPitStop.Entities.Produtos;

namespace OficinaPitStop.Services.Abstractions.Produtos
{
    public interface IProdutoService
    {
        IEnumerable<Produto> ObterPorFitlro(FiltrosProduto filtros);
        IEnumerable<Produto> ObterTodos();
        IEnumerable<Produto> ObterPorNome(string nomeProduto);

        bool Adiciona(Produto produto);
        bool Atualiza(Produto produto);
        bool Deleta(Produto produto);
    }
}
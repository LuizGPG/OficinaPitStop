using System.Collections.Generic;
using OficinaPitStop.Entities.Produtos;

namespace OficinaPitStop.Repositories.Abstractions.Repository
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> ObtemTodosProdutos();
    }
}
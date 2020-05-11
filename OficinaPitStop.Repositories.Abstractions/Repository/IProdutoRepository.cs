using System.Collections.Generic;
using OficinaPitStop.Entities.Produtos;

namespace OficinaPitStop.Repositories.Abstractions.Repository
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> ObterTodos();
        IEnumerable<Produto> ObterPorId(int idProduto);
        IEnumerable<Produto> ObterPorNome(string nomeProduto);
        IEnumerable<Produto> ObterPorCodigoMarca(IEnumerable<int> codigosMarcas);
        bool Adiciona(Produto produto);
        bool Atualiza(Produto produto);
        bool Deleta(Produto produto);
    }
}
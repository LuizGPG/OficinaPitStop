using System.Collections.Generic;
using System.Threading.Tasks;
using OficinaPitStop.Entities.Produtos;

namespace OficinaPitStop.Repositories.Abstractions.Repository
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> ObterTodos();
        Produto ObterPorId(int idProduto);
        Task<IEnumerable<Produto>> ObterPorNome(string nomeProduto);
        Task<IEnumerable<Produto>> ObterPorCodigoMarca(IEnumerable<int> codigosMarcas);
        bool Adiciona(Produto produto);
        bool Atualiza(Produto produto);
        bool Deleta(Produto produto);
    }
}
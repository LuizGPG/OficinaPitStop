using System.Collections.Generic;
using System.Threading.Tasks;
using OficinaPitStop.Entities.Produtos;

namespace OficinaPitStop.Repositories.Abstractions.Repository
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> ObterTodos();
        Task<IEnumerable<Produto>> ObterPorId(int idProduto);
        Task<IEnumerable<Produto>> ObterPorNome(string nomeProduto);
        Task<IEnumerable<Produto>> ObterPorCodigoMarca(IEnumerable<int> codigosMarcas);
        Task<bool> Adiciona(Produto produto);
        Task<bool> Atualiza(Produto produto);
        Task<bool> Deleta(Produto produto);
    }
}
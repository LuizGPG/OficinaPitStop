using System.Collections.Generic;
using System.Threading.Tasks;
using OficinaPitStop.Entities.Filtros.Produtos;
using OficinaPitStop.Entities.Produtos;

namespace OficinaPitStop.Services.Abstractions.Produtos
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> ObterPorFitlro(FiltrosProduto filtros);
        Task<IEnumerable<Produto>> ObterTodos();
        Task<IEnumerable<Produto>> ObterPorNome(string nomeProduto);

        Task<bool> Adiciona(Produto produto);
        Task<bool> Atualiza(Produto produto);
        Task<bool> Deleta(Produto produto);
    }
}
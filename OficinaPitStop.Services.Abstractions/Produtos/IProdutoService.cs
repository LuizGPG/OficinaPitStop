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

        bool Adiciona(Produto produto);
        bool Atualiza(Produto produto);
        bool Deleta(Produto produto);
    }
}
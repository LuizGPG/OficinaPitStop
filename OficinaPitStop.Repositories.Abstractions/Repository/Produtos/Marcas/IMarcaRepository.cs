using System.Collections.Generic;
using System.Threading.Tasks;
using OficinaPitStop.Entities.Produtos.Marcas;

namespace OficinaPitStop.Repositories.Abstractions.Repository.Produtos.Marcas
{
    public interface IMarcaRepository
    {
        Task<IEnumerable<Marca>> ObterTodos();
        Task<Marca> ObterPorId(int codigoMarca);
        Task<IEnumerable<Marca>> ObterPorNome(string descricao);
        Task<bool> Adiciona(Marca marca);
        Task<bool> Atualiza(Marca marca);
        Task<bool> Deleta(Marca marca);
    }
}
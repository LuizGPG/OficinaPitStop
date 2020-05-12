using System.Collections.Generic;
using System.Threading.Tasks;
using OficinaPitStop.Entities.Produtos.Marcas;

namespace OficinaPitStop.Services.Abstractions.Produtos.Marcas
{
    public interface IMarcaService
    {
        Task<IEnumerable<Marca>> ObterTodos();
        Task<Marca> ObterPorId(int codigoMarca);
        Task<IEnumerable<Marca>> ObterPorNome(string descricao);
        Task<bool> Adiciona(Marca marca);
        Task<bool> Atualiza(Marca marca);
        Task<bool> Deleta(Marca marca);
    }
}
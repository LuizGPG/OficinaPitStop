using System.Collections.Generic;
using System.Threading.Tasks;
using OficinaPitStop.Entities.Produtos.Marcas;

namespace OficinaPitStop.Services.Abstractions.Produtos.Marcas
{
    public interface IMarcaService
    {
        Task<IEnumerable<Marca>> ObterTodos();
        Marca ObterPorId(int codigoMarca);
        Task<IEnumerable<Marca>> ObterPorNome(string descricao);
        bool Adiciona(Marca marca);
        bool Atualiza(Marca marca);
        bool Deleta(Marca marca);
    }
}
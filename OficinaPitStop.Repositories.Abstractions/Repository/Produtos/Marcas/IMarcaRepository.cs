using System.Collections.Generic;
using System.Threading.Tasks;
using OficinaPitStop.Entities.Produtos.Marcas;

namespace OficinaPitStop.Repositories.Abstractions.Repository.Produtos.Marcas
{
    public interface IMarcaRepository
    {
        Task<IEnumerable<Marca>> ObterTodos();
        Marca ObterPorId(int codigoMarca);
        Task<IEnumerable<Marca>> ObterPorNome(string descricao);
        bool Adiciona(Marca marca);
        bool Atualiza(Marca marca);
        bool Deleta(Marca marca);
    }
}
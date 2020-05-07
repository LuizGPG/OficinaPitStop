using System.Collections.Generic;
using OficinaPitStop.Entities.Produtos.Marcas;

namespace OficinaPitStop.Repositories.Abstractions.Repository.Produtos.Marcas
{
    public interface IMarcaRepository
    {
        IEnumerable<Marca> ObterTodos();
        Marca ObterPorId(int codigoMarca);
        IEnumerable<Marca> ObterPorNome(string descricao);
        bool Adiciona(Marca marca);
        bool Atualiza(Marca marca);
        bool Deleta(Marca marca);
    }
}
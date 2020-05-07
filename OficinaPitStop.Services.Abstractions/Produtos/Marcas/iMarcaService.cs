using System.Collections.Generic;
using OficinaPitStop.Entities.Produtos;
using OficinaPitStop.Entities.Produtos.Marcas;

namespace OficinaPitStop.Services.Abstractions.Produtos.Marcas
{
    public interface IMarcaService
    {
        IEnumerable<Marca> ObterTodos();
        Marca ObterPorId(int codigoMarca);
        IEnumerable<Marca> ObterPorNome(string descricao);
        bool Adiciona(Marca marca);
        bool Atualiza(Marca marca);
        bool Deleta(Marca marca);
    }
}
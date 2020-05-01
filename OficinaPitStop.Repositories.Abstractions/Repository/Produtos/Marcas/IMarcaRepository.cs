using System.Collections.Generic;
using OficinaPitStop.Entities.Produtos.Marcas;

namespace OficinaPitStop.Repositories.Abstractions.Repository.Produtos.Marcas
{
    public interface IMarcaRepository
    {
        IEnumerable<Marca> ObtemTodasAsMarcas();
        Marca ObtemMarcaPorId(int codigoMarca);
        IEnumerable<Marca> ObterMarcasPorNome(string descricao);
    }
}
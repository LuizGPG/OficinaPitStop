using System.Collections.Generic;
using OficinaPitStop.Entities.Produtos.Marcas;

namespace OficinaPitStop.Services.Abstractions.Produtos.Marcas
{
    public interface IMarcaService
    {
        IEnumerable<Marca> ObtemTodasAsMarcas();
        Marca ObtemMarcaPorId(int codigoMarca);
        IEnumerable<Marca> ObterMarcasPorNome(string descricao);
    }
}
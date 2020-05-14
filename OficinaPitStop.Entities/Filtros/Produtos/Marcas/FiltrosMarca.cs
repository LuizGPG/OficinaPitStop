using System.Collections.Generic;

namespace OficinaPitStop.Entities.Filtros.Produtos.Marcas
{
    public class FiltrosMarca
    {
        public static string FiltroNomeMarca = "nome_marca";
        public string NomeMarca { get; set; }

        public static List<string> Filtros = new List<string>()
        {
            FiltroNomeMarca
        };
    }
}
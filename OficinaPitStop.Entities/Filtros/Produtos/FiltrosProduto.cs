using System.Collections.Generic;

namespace OficinaPitStop.Entities.Filtros.Produtos
{
    public class FiltrosProduto 
    {
        public static string FiltroNomeProduto = "nome_produto";
        public static string FiltroNomeMarcaProduto = "marca_produto";
        
        public string NomeProduto { get; set; }
        public string NomeMarcaProduto { get; set; }

        public FiltrosProduto()
        {
        }
        
        public static List<string> Filtros = new List<string>()
        {
            FiltroNomeProduto,
            FiltroNomeMarcaProduto
        };
    }
}
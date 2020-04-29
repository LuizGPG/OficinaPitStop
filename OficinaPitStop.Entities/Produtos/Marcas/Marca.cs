using System.ComponentModel.DataAnnotations;

namespace OficinaPitStop.Entities.Produtos.Marcas
{
    public class Marca
    {
        [Key]
        public int CodigoMarca { get; set; }

        public string Descricao { get; set; }
    }
}
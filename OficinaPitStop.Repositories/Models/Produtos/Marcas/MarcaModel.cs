using System.ComponentModel.DataAnnotations;

namespace OficinaPitStop.Repositories.Models.Produtos.Marcas
{
    public class MarcaModel
    {
        [Key]
        public int CodigoMarca { get; set; }

        public string Descricao { get; set; }
    }
}
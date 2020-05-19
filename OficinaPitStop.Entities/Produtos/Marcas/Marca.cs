using System.ComponentModel.DataAnnotations;

namespace OficinaPitStop.Entities.Produtos.Marcas
{
    public class Marca
    {
        public const string MarcaNaoEncontrada = "Marca não encontrada!";
        [Key]
        public int CodigoMarca { get; set; }
        public string Descricao { get; set; }
    }
}
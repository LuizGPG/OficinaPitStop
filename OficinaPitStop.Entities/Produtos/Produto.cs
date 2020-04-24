using System.ComponentModel.DataAnnotations;

namespace OficinaPitStop.Entities.Produtos
{
    public class Produto
    {
        [Key]
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public double Preco { get; set; }
    }
}
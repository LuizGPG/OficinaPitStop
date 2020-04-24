using System.ComponentModel.DataAnnotations;

namespace OficinaPitStop.Entities.Produtos
{
    public class Produto
    {
        [Key]
        public int id { get; set; }
        
        public string descricao { get; set; }

        public double quantidade { get; set; }
        public double preco { get; set; }
    }
}
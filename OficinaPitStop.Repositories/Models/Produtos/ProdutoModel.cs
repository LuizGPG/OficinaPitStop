using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace OficinaPitStop.Repositories.Models.Produtos
{
    public class ProdutoModel
    {
        [Key]
        public int id { get; set; }
        
        public string descricao { get; set; }

        public double quantidade { get; set; }
        public double preco { get; set; }
    }
}
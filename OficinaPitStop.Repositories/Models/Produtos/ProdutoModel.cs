using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace OficinaPitStop.Repositories.Models.Produtos
{
    public class ProdutoModel
    {
        [Key]
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public double Preco { get; set; }
    }
}
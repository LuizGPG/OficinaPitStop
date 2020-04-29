using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OficinaPitStop.Repositories.Models.Produtos.Marcas;

namespace OficinaPitStop.Repositories.Models.Produtos
{
    public class ProdutoModel
    {
        [Key]
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public double Preco { get; set; }
        
        public int CodigoMarca { get; set; }
    }
}
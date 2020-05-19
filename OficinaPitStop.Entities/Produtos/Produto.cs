using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OficinaPitStop.Entities.Produtos.Marcas;

namespace OficinaPitStop.Entities.Produtos
{
    public class Produto
    {
        public const string ProdutoNaoEncontrato = "Produto não encontrado!";
        public const string ErroAoModificarProduto = "Erro ao modificar produto!";
        [Key] 
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public double Preco { get; set; }
        public int CodigoMarca { get; set; }
        [NotMapped] public Marca Marca { get; set; }
    }
}
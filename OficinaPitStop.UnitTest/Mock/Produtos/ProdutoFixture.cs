using System.Collections.Generic;
using System.Linq;
using OficinaPitStop.Entities.Produtos;
using OficinaPitStop.Entities.Produtos.Marcas;

namespace OficinaPitStop.UnitTest.Mock.Produtos
{
    public class ProdutoFixture
    {
        public IEnumerable<Produto> ProdutoMock()
        {
            return new List<Produto>()
            {
                new Produto()
                {
                    Codigo = 1,
                    Descricao = "Produto Teste Descricao",
                    Marca = MarcasMock().First(),
                    Preco = 1.22,
                    Quantidade = 3.0,
                    CodigoMarca = 1
                }
            };
        }
        
        public IEnumerable<Marca> MarcasMock()
        {
            return new List<Marca>()
            {
                new Marca()
                {
                    CodigoMarca = 1,
                    Descricao = "Marca Teste Descricao 1"
                },
                new Marca()
                {
                    CodigoMarca = 2,
                    Descricao = "Marca Teste Descricao 2"
                }
            };
        } 
        
    }
}
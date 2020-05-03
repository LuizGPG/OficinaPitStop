using System.Collections.Generic;
using OficinaPitStop.Entities.Produtos;
using OficinaPitStop.Entities.Produtos.Marcas;

namespace OficinaPitStop.UnitTest.Mock
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
                    Marca = MarcaMock(),
                    Preco = 1.22,
                    Quantidade = 3.0,
                    CodigoMarca = 1
                }
            };
        }

        public Marca MarcaMock() =>
            new Marca()
            {
                CodigoMarca = 1,
                Descricao = "Marca Teste Descricao"
            };
    }
}
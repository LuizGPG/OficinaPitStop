using System.Collections.Generic;
using OficinaPitStop.Entities.Produtos.Marcas;

namespace OficinaPitStop.UnitTest.Mock.Produtos.Marcas
{
    public class MarcaFixture
    {
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
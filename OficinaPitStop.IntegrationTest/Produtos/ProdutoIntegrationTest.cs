using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OficinaPitStop.Entities.Produtos;
using Xunit;

namespace OficinaPitStop.IntegrationTest.Produtos
{
    public partial class ProdutoIntegrationTest : IntegrationTest
    {
        [Fact]
        public async Task Deve_Retornar_Consulta()
        {
            var response = await ExecutaComando(QueryObterTodosProdutos());
            response.EnsureSuccessStatusCode();
            var jObject = JsonConvert.DeserializeObject<JObject>(response.Content.ReadAsStringAsync().Result);
            var listaProdutosObj = jObject["data"]["produto"].ToString();
            var produtos = JsonConvert.DeserializeObject<IEnumerable<Produto>>(listaProdutosObj);


            Assert.NotEmpty(produtos);
        }
    }
}
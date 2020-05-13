using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OficinaPitStop.Api;
using OficinaPitStop.Entities.Produtos;
using Xunit;

namespace OficinaPitStop.IntegrationTest
{
    public class ProdutoIntegrationTest : IntegrationTest
    {

        [Fact]
        public async Task Deve_Retornar_Consulta()
        {
            var queryObject = new
            {
                query = @"{
                            produtos{
                                codigo
                            }
                          }"
            };
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = new StringContent(JsonConvert.SerializeObject(queryObject), Encoding.UTF8, "application/json")
            };

            var response = await Client.PostAsync("/graphql", request.Content);
            response.EnsureSuccessStatusCode();
            var retorno = await response.Content.ReadAsStringAsync();
            
            var jObject = JsonConvert.DeserializeObject<JObject>(response.Content.ReadAsStringAsync().Result);
            var nomeRetorno = jObject["data"].ToString();
            
            Assert.NotEmpty(retorno);
        }
    }
}
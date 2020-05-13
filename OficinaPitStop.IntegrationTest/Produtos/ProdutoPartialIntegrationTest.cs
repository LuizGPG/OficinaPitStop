using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OficinaPitStop.IntegrationTest.Produtos
{
    public partial class ProdutoIntegrationTest
    {

        private static string QueryObterTodosProdutos()
        {
            var queryObject = new
            {
                query = @"{
                            produto(nome_produto: ""2"") {
                              codigo
                              descricao
                              preco
                              quantidade
                            }
                          }"
            };

            return JsonConvert.SerializeObject(queryObject);
        }
        
        private async Task<HttpResponseMessage> ExecutaComando(string comando)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = new StringContent(comando, Encoding.UTF8, "application/json")
            };

            return await Client.PostAsync("/graphql", request.Content);
        }
      
    }
}
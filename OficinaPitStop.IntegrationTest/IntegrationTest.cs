using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using OficinaPitStop.Api;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OficinaPitStop.IntegrationTest

{
    public class IntegrationTest
    {
        protected readonly HttpClient Client;

        protected IntegrationTest()
        {
            string curDir = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder()
                .SetBasePath(curDir)
                .AddJsonFile("appsettings.json");
            
            var webBuilder = new WebHostBuilder()
                .UseContentRoot(curDir).UseConfiguration(builder.Build())
                .UseStartup<Startup>();

            var server = new TestServer(webBuilder);
            Client = server.CreateClient();
            Client.BaseAddress = new System.Uri("https://localhost:5001");
        }
        
        public async Task<JObject> ExecutaComando(string query)
        {
            var content = JsonConvert.SerializeObject(new {query});
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = new StringContent(content, Encoding.UTF8, "application/json")
            };

            var responseMessagem =  await Client.PostAsync("/graphql", request.Content);
            responseMessagem.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<JObject>(responseMessagem.Content.ReadAsStringAsync().Result);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using GraphQL.Server.Transports.AspNetCore.Common;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using OficinaPitStop.Api;
using OficinaPitStop.Entities.Produtos;
using Xunit;

namespace OficinaPitStop.IntegrationTest
{
    public class ProdutoIntegrationTest// : IntegrationTest
    {
        private readonly HttpClient _client;

        public ProdutoIntegrationTest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>()
            );
            _client = server.CreateClient();
            _client.BaseAddress = new Uri("https://localhost:5001");
        }

        [Fact]
        public async Task Deve_Retornar_Todos_Os_Produtos()
        {
            const string query = @"{
                ""query"": ""query { produtos { codigo } }""
            }";
            
            var content = new StringContent(query, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/graphql", content);
            
            //response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
        }
    }
}
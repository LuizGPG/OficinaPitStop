using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using GraphQL.Server.Transports.AspNetCore.Common;
using GraphQL.Client;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using OficinaPitStop.Entities.Produtos;
using OficinaPitStop.Repositories;
using Xunit;

namespace OficinaPitStop.IntegrationTest
{
    public class ProdutoIntegrationTest : IntegrationTest
    {

        [Fact]
        public async Task Deve_Retornar_Todos_Os_Produtos()
        {
            var query = @"{
                            produtos{
                                codigo
                            }
                          }";


            /*var response = await Client.GetAsync(query);
            (await response.Content.ReadAsAsync<List<Produto>>()).Should().BeEmpty();*/
            var input = new GraphQLRequest
            {
                Query = query
            };

            var endPoint = new GraphQLHttpClient("graphql", null);
            var cuAzedo = endPoint.SendQueryAsync<List<Produto>>(query);
            

        }
}

}
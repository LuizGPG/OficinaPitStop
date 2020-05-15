using System.Collections.Generic;
using System.Linq;
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
            var response = await ExecutaComando(QueryObterProdutoPorNome());
            response.EnsureSuccessStatusCode();
            var jObject = JsonConvert.DeserializeObject<JObject>(response.Content.ReadAsStringAsync().Result);
            var listaProdutosObj = jObject["data"]["produto"].ToString();
            var produtos = JsonConvert.DeserializeObject<IEnumerable<Produto>>(listaProdutosObj);

            Assert.NotEmpty(produtos);
        }

        [Fact]
        public async Task Deve_Modificar_Produto()
        {
            var response = await ExecutaComando(MutationAdicionarProduto());
            response.EnsureSuccessStatusCode();
            var jObject = JsonConvert.DeserializeObject<JObject>(response.Content.ReadAsStringAsync().Result);
            var cadastrouProduto = jObject["data"]["create_produto"].ToString();
            Assert.Equal("True", cadastrouProduto);

            //consulta
            var responseConsulta = await ExecutaComando(QueryObterTodosProdutos());
            jObject = JsonConvert.DeserializeObject<JObject>(responseConsulta.Content.ReadAsStringAsync().Result);
            var produtosObj = jObject["data"]["produtos"].ToString();
            var produtos = JsonConvert.DeserializeObject<IEnumerable<Produto>>(produtosObj);
            Assert.NotEmpty(produtos);

            var ultimoProduto = produtos.Last();

            //update
            var novaDescricao = "Novo descricao produto";
            var novoPreco = 78.4;
            ultimoProduto.Descricao = novaDescricao;
            ultimoProduto.Preco = novoPreco;
            var responseUpdate = await ExecutaComando(MutationAtualizaProduto(ultimoProduto));
            jObject = JsonConvert.DeserializeObject<JObject>(responseUpdate.Content.ReadAsStringAsync().Result);
            var atualizouProduto = jObject["data"]["update_produto"].ToString();
            Assert.Equal("True", atualizouProduto);

            //consulta
            responseConsulta = await ExecutaComando(QueryObterTodosProdutos());
            jObject = JsonConvert.DeserializeObject<JObject>(responseConsulta.Content.ReadAsStringAsync().Result);
            produtosObj = jObject["data"]["produtos"].ToString();
            produtos = JsonConvert.DeserializeObject<IEnumerable<Produto>>(produtosObj);
            Assert.NotEmpty(produtos);

            ultimoProduto = produtos.Last();

            Assert.Equal(novaDescricao, ultimoProduto.Descricao);
            Assert.Equal(novoPreco, ultimoProduto.Preco);

            //delete
            var responseDelete = await ExecutaComando(MutationDeletarProduto(ultimoProduto));
            jObject = JsonConvert.DeserializeObject<JObject>(responseDelete.Content.ReadAsStringAsync().Result);
            var deletouProduto = jObject["data"]["delete_produto"].ToString();
            Assert.Equal("True", deletouProduto);
        }
    }
}
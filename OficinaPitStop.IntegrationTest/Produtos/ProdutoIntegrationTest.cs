using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OficinaPitStop.Entities.Produtos;
using Xunit;

namespace OficinaPitStop.IntegrationTest.Produtos
{
    public partial class ProdutoIntegrationTest : IntegrationTest
    {

        [Fact]
        public async Task Deve_Fazer_Crud_De_Produto()
        {
            //Adiciona
            var jObject = await ExecutaComando(MutationAdicionarProduto);
            var cadastrouProduto = jObject["data"]["create_produto"].ToString();
            Assert.Equal("True", cadastrouProduto);

            //consulta
            jObject = await ExecutaComando(QueryObterTodosProdutos);
            var produtosObj = jObject["data"]["produtos"].ToString();
            var produtos = JsonConvert.DeserializeObject<IEnumerable<Produto>>(produtosObj);
            Assert.NotEmpty(produtos);

            var ultimoProduto = produtos.Last();

            //update
            var novaDescricao = "Novo descricao produto";
            var novoPreco = 78.4;
            ultimoProduto.Descricao = novaDescricao;
            ultimoProduto.Preco = novoPreco;
            jObject = await ExecutaComando(MutationAtualizaProduto(ultimoProduto));
            var atualizouProduto = jObject["data"]["update_produto"].ToString();
            Assert.Equal("True", atualizouProduto);

            //consulta
            jObject = await ExecutaComando(QueryObterProdutoPorNome(ultimoProduto));
            var listaProdutosObj = jObject["data"]["produto"].ToString();
            produtos = JsonConvert.DeserializeObject<IEnumerable<Produto>>(listaProdutosObj);
            Assert.NotEmpty(produtos);

            ultimoProduto = produtos.Last();

            Assert.Equal(novaDescricao, ultimoProduto.Descricao);
            Assert.Equal(novoPreco, ultimoProduto.Preco);

            //delete
            jObject = await ExecutaComando(MutationDeletarProduto(ultimoProduto));
            var deletouProduto = jObject["data"]["delete_produto"].ToString();
            Assert.Equal("True", deletouProduto);
        }
    }
}
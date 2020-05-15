using System;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OficinaPitStop.Entities.Produtos;

namespace OficinaPitStop.IntegrationTest.Produtos
{
    public partial class ProdutoIntegrationTest
    {
        #region QueryObterProdutoPorNome

        private static string QueryObterProdutoPorNome()
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

        #endregion

        #region QueryObterTodosProdutos
        private static string QueryObterTodosProdutos()
        {
            var queryObject = new
            {
                query = @"{
                            produtos{
                              codigo
                              descricao
                              marca{
                                codigoMarca
                                descricao
                              }
                              preco
                              quantidade
                            }
                          }"
            };
            return JsonConvert.SerializeObject(queryObject);
        }
        #endregion

        #region MutationAtualizaProduto
        private static string MutationAtualizaProduto(Produto produto)
        {
            var query = @"
                            mutation{
                                update_produto(update:{
                                  codigo: @codigoProduto
                                  descricao: ""@descricaoProduto""
                                  preco:@precoProduto
                                  })
                            }
                          ";
            query = query
                .Replace("@codigoProduto", produto.Codigo.ToString())
                .Replace("@descricaoProduto", produto.Descricao)
                .Replace("@precoProduto", produto.Preco.ToString(CultureInfo.InvariantCulture));

            var queryObject = new {query};
            return JsonConvert.SerializeObject(queryObject);
        }
        #endregion


        #region MutationDeletarProduto
        private static string MutationDeletarProduto(Produto produto)
        {
            var query = @"
                            mutation{
                              delete_produto(delete:{
                                codigo:@codigoProduto
                              })
                            }
                          ";
            query = query
                .Replace("@codigoProduto", produto.Codigo.ToString());

            var queryObject = new {query};
            return JsonConvert.SerializeObject(queryObject);
        }
        #endregion
        
        #region MutationAdicionarProduto
        private static string MutationAdicionarProduto()
        {
            var queryObject = new
            {
                query = @"mutation{
                    create_produto(create:{
                        descricao:""Descricao produto inserido no teste de integracao""
                        preco:15.11
                        quantidade:14
                    })
                }"
            };

            return JsonConvert.SerializeObject(queryObject);
        }
        #endregion
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
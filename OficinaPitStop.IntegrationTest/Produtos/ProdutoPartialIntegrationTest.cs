using System.Globalization;
using OficinaPitStop.Entities.Produtos;

namespace OficinaPitStop.IntegrationTest.Produtos
{
    public partial class ProdutoIntegrationTest
    {
        #region QueryObterProdutoPorNome

        private static string QueryObterProdutoPorNome(Produto produto)
        {
            return @"{
                            produto(nome_produto: ""@nomeProduto"") {
                              codigo
                              descricao
                              preco
                              quantidade
                            }
                          }".Replace("@nomeProduto", produto.Descricao);
        }

        #endregion

        #region QueryObterTodosProdutos

        private static string QueryObterTodosProdutos =
            @"{
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
             }";
    
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
                          "
                .Replace("@codigoProduto", produto.Codigo.ToString())
                .Replace("@descricaoProduto", produto.Descricao)
                .Replace("@precoProduto", produto.Preco.ToString(CultureInfo.InvariantCulture));
            
            return query;
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

            return query;
        }
        #endregion
        
        #region MutationAdicionarProduto
        private static string MutationAdicionarProduto =
             @"mutation{
                    create_produto(create:{
                        descricao:""Descricao produto inserido no teste de integracao""
                        preco:15.11
                        quantidade:14
                    })
                }";
        
        #endregion
    }
}
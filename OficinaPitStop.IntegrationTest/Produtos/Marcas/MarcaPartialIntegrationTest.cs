using OficinaPitStop.Entities.Produtos.Marcas;

namespace OficinaPitStop.IntegrationTest.Produtos.Marcas
{
    public partial class MarcaIntegrationTest
    {
        private static string MutationAdicionarMarca()
        {
            return @"mutation{
                    create_marca(create:{
                      descricao:""Criando via teste de integracao!""
                          })
                      }";
        }
        
        private static string MutationAtualizaMarca(Marca marca)
        {
             return @"mutation{
                    update_marca(update:{
                      codigoMarca:@codigoMarca
                      descricao:""@descricao""
                          })
                      }"
                      .Replace("@codigoMarca", marca.CodigoMarca.ToString())
                      .Replace("@descricao", marca.Descricao);
        }
        
        private static string MutationDeletaMarca(Marca marca)
        {
            return @"mutation{
                      delete_marca(delete:{
                        codigoMarca:@codigoMarca
                      })
                    }"
                .Replace("@codigoMarca", marca.CodigoMarca.ToString());
        }

        private static string QueryObterMarcasPorNome(string marca)
        {
            return @"{
                    marca(nome_marca:""@marca""){
                        descricao
                        codigoMarca
                       }
                    }".Replace("@marca", marca);
        }
        
        private static string QueryObterTodasAsMarcas()
        {
            return @"{
                      marcas{
                        codigoMarca
                        descricao
                      }
                    }";
        }
    }
}
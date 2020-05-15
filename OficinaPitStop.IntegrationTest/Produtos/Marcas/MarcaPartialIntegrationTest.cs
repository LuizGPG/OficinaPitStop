namespace OficinaPitStop.IntegrationTest.Produtos.Marcas
{
    public partial class MarcaIntegrationTest
    {
        private static string MutationAdicionarMarca()
        {
            return @"mutation{
                    create_marca(create:{
                      descricao:""Criando via mutation""
                          })
                      }";
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OficinaPitStop.Entities.Produtos.Marcas;
using Xunit;

namespace OficinaPitStop.IntegrationTest.Produtos.Marcas
{
    public partial class MarcaIntegrationTest : IntegrationTest
    {
        [Fact]
        public async Task Deve_Fazer_Crud_De_Marca()
        {
            //Adiciona
            var jObject = await ExecutaComando(MutationAdicionarMarca());
            var cadastrouMarca = jObject["data"]["create_marca"].ToString();
            Assert.Equal("True", cadastrouMarca);

            //consulta
            jObject = await ExecutaComando(QueryObterTodasAsMarcas());
            var marcasObj = jObject["data"]["marcas"].ToString();
            var marcas = JsonConvert.DeserializeObject<IEnumerable<Marca>>(marcasObj);
            Assert.NotEmpty(marcas);

            var ultimaMarca = marcas.Last();

            //update
            var novaDescricao = "Descricao marca Teste integracao";
            ultimaMarca.Descricao = novaDescricao;
            
            jObject = await ExecutaComando(MutationAtualizaMarca(ultimaMarca));
            var atualizouMarca = jObject["data"]["update_marca"].ToString();
            Assert.Equal("True", atualizouMarca);

            //consulta
            jObject = await ExecutaComando(QueryObterMarcasPorNome(novaDescricao));
            marcasObj = jObject["data"]["marca"].ToString();
            marcas = JsonConvert.DeserializeObject<IEnumerable<Marca>>(marcasObj);

            ultimaMarca = marcas.Last();

            Assert.Equal(novaDescricao, ultimaMarca.Descricao);

            //delete
            jObject = await ExecutaComando(MutationDeletaMarca(ultimaMarca));
            var deletouMarca = jObject["data"]["delete_marca"].ToString();
            Assert.Equal("True", deletouMarca);
            
        }
    }
}
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OficinaPitStop.Entities.Produtos.Marcas;
using OficinaPitStop.Repositories;
using OficinaPitStop.Repositories.Repository.Produtos.Marcas;
using Xunit;

namespace OficinaPitStop.UnitTest.Produtos.Marcas
{
    public class MarcaRepositoryTest
    {
        [Fact]
        public async Task Deve_Retornar_Consultas_De_Marca()
        {
            var options = new DbContextOptionsBuilder<OficinaPitStopContext>()
                .UseInMemoryDatabase("Testes_Consulta_Marcas")
                .Options;

            using (var context = new OficinaPitStopContext(options))
            {
                PreencheMarcas(context);
                var marcaRepository = new MarcaRepository(context);
                var marcas = await marcaRepository.ObterTodos();
                Assert.NotEmpty(marcas);

                var marca = marcas.First();
                
                var retornoPorId = await marcaRepository.ObterPorId(marca.CodigoMarca);
                Assert.NotNull(retornoPorId);

                var retornoPorNome = await marcaRepository.ObterPorNome(marca.Descricao);
                Assert.NotEmpty(retornoPorNome);
            }
        }
        
        [Fact]
        public async Task Deve_Adicionar_Atualizar_E_Deletar_Marca()
        {
            var options = new DbContextOptionsBuilder<OficinaPitStopContext>()
                .UseInMemoryDatabase("Testes_Modifica_Marcas")
                .Options;

            using (var context = new OficinaPitStopContext(options))
            {
                //Cria
                var marcaRepository = new MarcaRepository(context);
                var marca = CriaMarca(1);
                var retornoAdiciona = await marcaRepository.Adiciona(marca);
                Assert.True(retornoAdiciona);
                
                var retornoPorId = await marcaRepository.ObterPorId(marca.CodigoMarca);
                Assert.NotNull(retornoPorId);

                //Atualiza
                var descricaoAntigaMarca = retornoPorId.Descricao;
                var novaDescricaoMarca = "Nova descrição marca!";
                marca.Descricao = novaDescricaoMarca;
                var retornoAtualiza = await marcaRepository.Atualiza(marca);
                Assert.True(retornoAtualiza);
                
                retornoPorId = await marcaRepository.ObterPorId(marca.CodigoMarca);
                Assert.NotEqual(retornoPorId.Descricao, descricaoAntigaMarca);
                Assert.Equal(retornoPorId.Descricao, novaDescricaoMarca);
                
                //Deleta
                var retornoDelete = await marcaRepository.Deleta(marca);
                Assert.True(retornoDelete);
                
                retornoPorId = await marcaRepository.ObterPorId(marca.CodigoMarca);
                Assert.Null(retornoPorId);

            }
        }
        
        private void PreencheMarcas(OficinaPitStopContext context)
        {
            var marcas = new[]
            {
                CriaMarca(1),
                CriaMarca(2)
            };

            context.Marca.AddRange(marcas);
            context.SaveChanges();
        }

        private static Marca CriaMarca(int codigo)
        {
            return new Marca()
            {
                CodigoMarca = codigo,
                Descricao = "Descricao marca",
            };
        }
    }
}
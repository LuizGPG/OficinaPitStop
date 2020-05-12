using System.Linq;
using System.Threading.Tasks;
using Moq;
using OficinaPitStop.Entities.Produtos.Marcas;
using OficinaPitStop.Repositories.Abstractions.Repository.Produtos.Marcas;
using OficinaPitStop.Services.Produtos.Marcas;
using OficinaPitStop.UnitTest.Mock.Produtos.Marcas;
using Xunit;

namespace OficinaPitStop.UnitTest.Produtos.Marcas
{
    public class MarcaServiceTests : IClassFixture<MarcaFixture>
    {
        private readonly MarcaFixture _marcaFixture;

        public MarcaServiceTests(MarcaFixture marcaFixture)
        {
            _marcaFixture = marcaFixture;
        }

        [Fact]
        public async Task Deve_Retornar_Todas_As_Marcas()
        {
            var marcas = _marcaFixture.MarcasMock();
            var marcaRepository = new Mock<IMarcaRepository>();

            marcaRepository.Setup(m => m.ObterTodos())
                .ReturnsAsync(marcas);

            var marcaService = new MarcaService(marcaRepository.Object);
            var marcasRetorno = await marcaService.ObterTodos();

            Assert.Equal(marcasRetorno, marcas);
        }

        [Fact]
        public async Task Deve_Retornar_Marca_Por_Id()
        {
            var marca = _marcaFixture.MarcasMock().First();
            var marcaRepository = new Mock<IMarcaRepository>();

            marcaRepository.Setup(m => m.ObterPorId(It.IsAny<int>()))
                .ReturnsAsync(marca);

            var marcaService = new MarcaService(marcaRepository.Object);
            var marcasRetorno = await marcaService.ObterPorId(marca.CodigoMarca);

            Assert.Equal(marcasRetorno, marca);
        }
        
        [Fact]
        public async Task Deve_Retornar_Marca_Por_Nome()
        {
            var marca = _marcaFixture.MarcasMock();
            var marcaRepository = new Mock<IMarcaRepository>();

            marcaRepository.Setup(m => m.ObterPorNome(It.IsAny<string>()))
                .ReturnsAsync(marca);

            var marcaService = new MarcaService(marcaRepository.Object);
            var marcasRetorno = await marcaService.ObterPorNome(marca.First().Descricao);

            Assert.Equal(marcasRetorno, marca);
        }

        [Fact]
        public async Task Deve_Criar_Marca()
        {
            var marca = _marcaFixture.MarcasMock().First();
            var marcaRepository = new Mock<IMarcaRepository>();

            marcaRepository.Setup(m => m.Adiciona(It.IsAny<Marca>()))
                .ReturnsAsync(true);
            
            var marcaService = new MarcaService(marcaRepository.Object);
            var retorno = await marcaService.Adiciona(marca);

            Assert.True(retorno);
        }
        
        [Fact]
        public async Task Deve_Atualizar_Marca()
        {
            var marca = _marcaFixture.MarcasMock().First();
            var marcaRepository = new Mock<IMarcaRepository>();

            marcaRepository.Setup(m => m.ObterPorId(It.IsAny<int>()))
                .ReturnsAsync(marca);
            marcaRepository.Setup(m => m.Atualiza(It.IsAny<Marca>()))
                .ReturnsAsync(true);
            
            var marcaService = new MarcaService(marcaRepository.Object);
            var retorno = await marcaService.Atualiza(marca);

            Assert.True(retorno);
        }
        
        [Fact]
        public async Task Deve_Excluir_Marca()
        {
            var marca = _marcaFixture.MarcasMock().First();
            var marcaRepository = new Mock<IMarcaRepository>();

            marcaRepository.Setup(m => m.ObterPorId(It.IsAny<int>()))
                .ReturnsAsync(marca);
            
            marcaRepository.Setup(m => m.Deleta(It.IsAny<Marca>()))
                .ReturnsAsync(true);
            
            var marcaService = new MarcaService(marcaRepository.Object);
            var retorno = await marcaService.Deleta(marca);

            Assert.True(retorno);
        }
    }
}
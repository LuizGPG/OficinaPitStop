using System.Linq;
using Moq;
using OficinaPitStop.Repositories.Abstractions.Repository.Produtos.Marcas;
using OficinaPitStop.Services.Produtos.Marcas;
using OficinaPitStop.UnitTest.Mock.Produtos.Marcas;
using Xunit;

namespace OficinaPitStop.UnitTest.Produtos.Marcas
{
    public class MarcaTests : IClassFixture<MarcaFixture>
    {
        private readonly MarcaFixture _marcaFixture;

        public MarcaTests(MarcaFixture marcaFixture)
        {
            _marcaFixture = marcaFixture;
        }

        [Fact]
        public void Deve_Retornar_Todas_As_Marcas()
        {
            var marcas = _marcaFixture.MarcasMock();
            var marcaRepository = new Mock<IMarcaRepository>();

            marcaRepository.Setup(m => m.ObterTodos())
                .Returns(marcas);

            var marcaService = new MarcaService(marcaRepository.Object);
            var marcasRetorno = marcaService.ObterTodos();

            Assert.Equal(marcasRetorno, marcas);
        }

        [Fact]
        public void Deve_Retornar_Marca_Por_Id()
        {
            var marca = _marcaFixture.MarcasMock().First();
            var marcaRepository = new Mock<IMarcaRepository>();

            marcaRepository.Setup(m => m.ObterPorId(It.IsAny<int>()))
                .Returns(marca);

            var marcaService = new MarcaService(marcaRepository.Object);
            var marcasRetorno = marcaService.ObterPorId(marca.CodigoMarca);

            Assert.Equal(marcasRetorno, marca);
        }
        
        [Fact]
        public void Deve_Retornar_Marca_Por_Nome()
        {
            var marca = _marcaFixture.MarcasMock();
            var marcaRepository = new Mock<IMarcaRepository>();

            marcaRepository.Setup(m => m.ObterPorNome(It.IsAny<string>()))
                .Returns(marca);

            var marcaService = new MarcaService(marcaRepository.Object);
            var marcasRetorno = marcaService.ObterPorNome(marca.First().Descricao);

            Assert.Equal(marcasRetorno, marca);
        }
    }
}
using System;
using System.Linq;
using Moq;
using OficinaPitStop.Entities.Produtos;
using OficinaPitStop.Repositories.Abstractions.Repository;
using OficinaPitStop.Services.Abstractions.Produtos.Marcas;
using OficinaPitStop.Services.Produtos;
using OficinaPitStop.UnitTest.Mock.Produtos;
using OficinaPitStop.UnitTest.Mock.Produtos.Marcas;
using Xunit;
using Assert = Xunit.Assert;

namespace OficinaPitStop.UnitTest.Produtos
{
    public class ProdutoTests : IClassFixture<ProdutoFixture>
    {
        private readonly ProdutoFixture _produtoFixture;
        public static FiltrosProduto filtrosProduto;

        public ProdutoTests(ProdutoFixture produtoFixture)
        {
            _produtoFixture = produtoFixture;
            filtrosProduto = new FiltrosProduto();
        }

        [Fact]
        public void Deve_Buscar_Todos_Os_Produtos()
        {
            var produtosMock = _produtoFixture.ProdutoMock();

            var produtoRespository = new Mock<IProdutoRepository>();
            var marcaService = new Mock<IMarcaService>();

            produtoRespository.Setup(x => x.ObtemTodosProdutos())
                .Returns(produtosMock);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = service.ObtemTodosProdutos();

            Assert.Equal(produtosRetorno, produtosMock);
        }

        [Fact]
        public void Deve_Buscar_Produto_Por_Nome()
        {
            var produtosMock = _produtoFixture.ProdutoMock();

            var produtoRespository = new Mock<IProdutoRepository>();
            var marcaService = new Mock<IMarcaService>();
            produtoRespository.Setup(x => x.ObtemProdutosPorNome(It.IsAny<string>()))
                .Returns(produtosMock);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = service.ObtemProdutosPorNome(produtosMock.First().Descricao);

            Assert.Equal(produtosRetorno, produtosMock);
        }

        [Fact(Skip = "Nao funciona esse caralho")]
        public void Deve_Buscar_Produto_Por_Marca()
        {
            var produtosMock = _produtoFixture.ProdutoMock();
            var marcasMock = _produtoFixture.MarcasMock();

            var marcaService = new Mock<IMarcaService>();
            var produtoRespository = new Mock<IProdutoRepository>();

            marcaService.Setup(m => m.ObterMarcasPorNome(It.IsAny<string>()))
                .Returns(marcasMock);

            produtoRespository.Setup(x => x.ObterProdutoPorCodigoMarca(It.IsAny<int[]>()))
                .Returns(produtosMock);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = service.ObterProdutosPorMarca(produtosMock.First().Descricao);

            Assert.Equal(produtosRetorno, produtosMock);
        }

        [Fact]
        public void Deve_Retornar_Produto_Usando_Filtro_De_Produto()
        {
            var produtosMock = _produtoFixture.ProdutoMock();
            var marcasMock = _produtoFixture.MarcasMock();
            filtrosProduto.NomeProduto = produtosMock.First().Descricao;

            var marcaService = new Mock<IMarcaService>();
            var produtoRespository = new Mock<IProdutoRepository>();

            produtoRespository.Setup(x => x.ObtemProdutosPorNome(It.IsAny<string>()))
                .Returns(produtosMock);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = service.ObterProdutosPorFitlro(filtrosProduto);

            Assert.Equal(produtosRetorno, produtosMock);
        }

        [Fact(Skip = "Resolver aquele problema")]
        public void Deve_Retornar_Produto_Usando_Filtro_De_Marca()
        {
            var produtosMock = _produtoFixture.ProdutoMock();
            var marcasMock = _produtoFixture.MarcasMock();
            filtrosProduto.NomeMarcaProduto = produtosMock.First().Marca.Descricao;

            var marcaService = new Mock<IMarcaService>();
            var produtoRespository = new Mock<IProdutoRepository>();

            marcaService.Setup(m => m.ObterMarcasPorNome(It.IsAny<string>()))
                .Returns(marcasMock);

            produtoRespository.Setup(x => x.ObterProdutoPorCodigoMarca(It.IsAny<int[]>()))
                .Returns(produtosMock);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = service.ObterProdutosPorFitlro(filtrosProduto);

            Assert.Equal(produtosRetorno, produtosMock);
        }

        [Fact(Skip = "Resolver aquele problema")]
        public void Deve_Retornar_Produto_Usando_Filtro_De_Produto_E_Marca()
        {
            var produtosMock = _produtoFixture.ProdutoMock();
            var marcasMock = _produtoFixture.MarcasMock();
            filtrosProduto.NomeProduto = produtosMock.First().Descricao;
            filtrosProduto.NomeMarcaProduto = produtosMock.First().Marca.Descricao;

            var marcaService = new Mock<IMarcaService>();
            var produtoRespository = new Mock<IProdutoRepository>();

            marcaService.Setup(m => m.ObterMarcasPorNome(It.IsAny<string>()))
                .Returns(marcasMock);

            produtoRespository.Setup(x => x.ObterProdutoPorCodigoMarca(It.IsAny<int[]>()))
                .Returns(produtosMock);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = service.ObterProdutosPorFitlro(filtrosProduto);

            Assert.Equal(produtosRetorno, produtosMock);
        }

        [Fact]
        public void Deve_Retornar_Produto_Usando_Sem_Filtro()
        {
            var produtosMock = _produtoFixture.ProdutoMock();
            var marcasMock = _produtoFixture.MarcasMock();

            var marcaService = new Mock<IMarcaService>();
            var produtoRespository = new Mock<IProdutoRepository>();

            produtoRespository.Setup(x => x.ObtemTodosProdutos())
                .Returns(produtosMock);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = service.ObterProdutosPorFitlro(filtrosProduto);

            Assert.Equal(produtosRetorno, produtosMock);
        }
    }
}
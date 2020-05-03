using System.Collections.Generic;
using System.Linq;
using Moq;
using OficinaPitStop.Entities.Produtos;
using OficinaPitStop.Entities.Produtos.Marcas;
//using NUnit.Framework;
using OficinaPitStop.Repositories.Abstractions.Repository;
using OficinaPitStop.Repositories.Abstractions.Repository.Produtos.Marcas;
using OficinaPitStop.Repositories.Repository.Produtos;
using OficinaPitStop.Services.Produtos;
using OficinaPitStop.UnitTest.Mock;
using Xunit;
using Assert = Xunit.Assert;

namespace OficinaPitStop.UnitTest
{
    public class ProdutosTests : IClassFixture<ProdutoFixture>
    {
        private readonly ProdutoFixture _produtoFixture;
        public ProdutosTests(ProdutoFixture produtoFixture)
        {
            _produtoFixture = produtoFixture;
        }

        [Fact]
        public void Deve_Buscar_Todos_Os_Produtos()
        {
            var produtosMock = _produtoFixture.ProdutoMock();

            var produtoService = new Mock<IProdutoRepository>();
            var marcaService = new Mock<IMarcaRepository>();
            produtoService.Setup(x => x.ObtemTodosProdutos())
                .Returns(produtosMock);

            var service = new ProdutoService(produtoService.Object, marcaService.Object);
            var produtosRetorno = service.ObtemTodosProdutos();

            Assert.Equal(produtosRetorno, produtosMock);
        }
        
        [Fact]
        public void Deve_Buscar_Produto_Por_Nome()
        {
            var produtosMock = _produtoFixture.ProdutoMock();

            var produtoService = new Mock<IProdutoRepository>();
            var marcaService = new Mock<IMarcaRepository>();
            produtoService.Setup(x => x.ObtemProdutosPorNome(It.IsAny<string>()))
                .Returns(produtosMock);

            var service = new ProdutoService(produtoService.Object, marcaService.Object);
            var produtosRetorno = service.ObtemProdutosPorNome(produtosMock.First().Descricao);

            Assert.Equal(produtosRetorno, produtosMock);
        }
        
        [Fact]
        public void Deve_Buscar_Produto_Por_Marca()
        {
            var produtosMock = _produtoFixture.ProdutoMock();
            var marcasMock = _produtoFixture.MarcaMock();
            List<Marca> marcas = new List<Marca>(){marcasMock};

            var marcaService = new Mock<IMarcaRepository>();
            marcaService.Setup(x => x.ObterMarcasPorNome(It.IsAny<string>()))
                .Returns(marcas);
            
            var produtoService = new Mock<IProdutoRepository>();
            produtoService.Setup(x => x.ObterProdutoPorCodigoMarca(It.IsAny<int[]>()))
                .Returns(new List<Produto>()
                {
                    new Produto()
                    {
                        Descricao = "teste 7745"
                    }
                });

            var service = new ProdutoService(produtoService.Object, marcaService.Object);
            var produtosRetorno = service.ObterProdutosPorMarca(produtosMock.First().Descricao);

            Assert.Equal(produtosRetorno, produtosMock);
        }
    }
}
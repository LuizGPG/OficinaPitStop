using System.Collections.Generic;
using System.Linq;
using Moq;
using OficinaPitStop.Entities.Filtros.Produtos;
using OficinaPitStop.Entities.Produtos;
using OficinaPitStop.Repositories.Abstractions.Repository;
using OficinaPitStop.Services.Abstractions.Produtos.Marcas;
using OficinaPitStop.Services.Execptions;
using OficinaPitStop.Services.Produtos;
using OficinaPitStop.UnitTest.Mock.Produtos;
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

            produtoRespository.Setup(x => x.ObterTodos())
                .Returns(produtosMock);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = service.ObterTodos();

            Assert.Equal(produtosRetorno, produtosMock);
        }

        [Fact]
        public void Deve_Buscar_Produto_Por_Nome()
        {
            var produtosMock = _produtoFixture.ProdutoMock();

            var produtoRespository = new Mock<IProdutoRepository>();
            var marcaService = new Mock<IMarcaService>();
            produtoRespository.Setup(x => x.ObterPorNome(It.IsAny<string>()))
                .Returns(produtosMock);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = service.ObterPorNome(produtosMock.First().Descricao);

            Assert.Equal(produtosRetorno, produtosMock);
        }

        [Fact]
        public void Deve_Buscar_Produto_Por_Marca()
        {
            var produtosMock = _produtoFixture.ProdutoMock();
            var marcasMock = _produtoFixture.MarcasMock();

            var marcaService = new Mock<IMarcaService>();
            var produtoRespository = new Mock<IProdutoRepository>();

            marcaService.Setup(m => m.ObterPorNome(It.IsAny<string>()))
                .Returns(marcasMock);

            produtoRespository.Setup(x => x.ObterPorCodigoMarca(It.IsAny<IEnumerable<int>>()))
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

            produtoRespository.Setup(x => x.ObterPorNome(It.IsAny<string>()))
                .Returns(produtosMock);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = service.ObterPorFitlro(filtrosProduto);

            Assert.Equal(produtosRetorno, produtosMock);
        }

        [Fact]
        public void Deve_Retornar_Produto_Usando_Filtro_De_Marca()
        {
            var produtosMock = _produtoFixture.ProdutoMock();
            var marcasMock = _produtoFixture.MarcasMock();
            filtrosProduto.NomeMarcaProduto = produtosMock.First().Marca.Descricao;

            var marcaService = new Mock<IMarcaService>();
            var produtoRespository = new Mock<IProdutoRepository>();

            marcaService.Setup(m => m.ObterPorNome(It.IsAny<string>()))
                .Returns(marcasMock);

            produtoRespository.Setup(x => x.ObterPorCodigoMarca(It.IsAny<IEnumerable<int>>()))
                .Returns(produtosMock);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = service.ObterPorFitlro(filtrosProduto);

            Assert.Equal(produtosRetorno, produtosMock);
        }

        [Fact]
        public void Deve_Retornar_Produto_Usando_Filtro_De_Produto_E_Marca()
        {
            var produtosMock = _produtoFixture.ProdutoMock();
            var marcasMock = _produtoFixture.MarcasMock();
            filtrosProduto.NomeProduto = produtosMock.First().Descricao;
            filtrosProduto.NomeMarcaProduto = produtosMock.First().Marca.Descricao;

            var marcaService = new Mock<IMarcaService>();
            var produtoRespository = new Mock<IProdutoRepository>();

            marcaService.Setup(m => m.ObterPorNome(It.IsAny<string>()))
                .Returns(marcasMock);

            produtoRespository.Setup(x => x.ObterPorCodigoMarca(It.IsAny<IEnumerable<int>>()))
                .Returns(produtosMock);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = service.ObterPorFitlro(filtrosProduto);

            Assert.Equal(produtosRetorno, produtosMock);
        }

        [Fact]
        public void Deve_Retornar_Produto_Usando_Sem_Filtro()
        {
            var produtosMock = _produtoFixture.ProdutoMock();
            var marcasMock = _produtoFixture.MarcasMock();

            var marcaService = new Mock<IMarcaService>();
            var produtoRespository = new Mock<IProdutoRepository>();

            produtoRespository.Setup(x => x.ObterTodos())
                .Returns(produtosMock);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = service.ObterPorFitlro(filtrosProduto);

            Assert.Equal(produtosRetorno, produtosMock);
        }

        [Fact]
        public void Deve_Criar_Produto()
        {
            var produtosMock = _produtoFixture.ProdutoMock().First();
            var marcasMock = _produtoFixture.MarcasMock();

            var marcaService = new Mock<IMarcaService>();
            var produtoRespository = new Mock<IProdutoRepository>();

            produtoRespository.Setup(x => x.Adiciona(It.IsAny<Produto>()))
                .Returns(true);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = service.Adiciona(produtosMock);

            Assert.True(produtosRetorno);
        }

        [Fact]
        public void Deve_Atualizar_Produto()
        {
            var produtosMock = _produtoFixture.ProdutoMock();
            var marcasMock = _produtoFixture.MarcasMock();

            var marcaService = new Mock<IMarcaService>();
            var produtoRespository = new Mock<IProdutoRepository>();

            produtoRespository.Setup(x => x.ObterPorId(It.IsAny<int>()))
                .Returns(produtosMock);

            produtoRespository.Setup(x => x.Atualiza(It.IsAny<Produto>()))
                .Returns(true);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = service.Atualiza(produtosMock.First());

            Assert.True(produtosRetorno);
        }
        
        [Fact]
        public void Deve_Dar_Erro_Ao_Atualizar_Produto_E_Nao_Encontrar_ID()
        {
            var produtosMock = _produtoFixture.ProdutoMock();
            var marcasMock = _produtoFixture.MarcasMock();
            var mensagemErro = "Produto não encontrado para atualizar!";

            var marcaService = new Mock<IMarcaService>();
            var produtoRespository = new Mock<IProdutoRepository>();

            produtoRespository.Setup(x => x.Atualiza(It.IsAny<Produto>()))
                .Throws(new NotFoundExepction(mensagemErro));

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = Assert.ThrowsAsync<NotFoundExepction>(
                async () => service.Atualiza(produtosMock.First()));

            Assert.Equal(mensagemErro, produtosRetorno.Result.Message);
        }

        [Fact]
        public void Deve_Deletar_Produto()
        {
            var produtosMock = _produtoFixture.ProdutoMock();
            var marcasMock = _produtoFixture.MarcasMock();

            var marcaService = new Mock<IMarcaService>();
            var produtoRespository = new Mock<IProdutoRepository>();

            produtoRespository.Setup(x => x.ObterPorId(It.IsAny<int>()))
                .Returns(produtosMock);

            produtoRespository.Setup(x => x.Deleta(It.IsAny<Produto>()))
                .Returns(true);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = service.Deleta(produtosMock.First());

            Assert.True(produtosRetorno);
        }
        
        [Fact]
        public void Deve_Dar_Erro_Ao_Deletar_Produto_E_Nao_Encontrar_ID()
        {
            var produtosMock = _produtoFixture.ProdutoMock();
            var marcasMock = _produtoFixture.MarcasMock();
            var mensagemErro = "Produto não encontrado para deletar!";

            var marcaService = new Mock<IMarcaService>();
            var produtoRespository = new Mock<IProdutoRepository>();

            produtoRespository.Setup(x => x.Deleta(It.IsAny<Produto>()))
                .Throws(new NotFoundExepction(mensagemErro));

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = Assert.ThrowsAsync<NotFoundExepction>(
                async () => service.Deleta(produtosMock.First()));

            Assert.Equal(mensagemErro, produtosRetorno.Result.Message);
        }
    }
}
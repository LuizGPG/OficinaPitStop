using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class ProdutoServiceTests : IClassFixture<ProdutoFixture>
    {
        private readonly ProdutoFixture _produtoFixture;
        public static FiltrosProduto FiltrosProduto;

        public ProdutoServiceTests(ProdutoFixture produtoFixture)
        {
            _produtoFixture = produtoFixture;
            FiltrosProduto = new FiltrosProduto();
        }

        [Fact]
        public async Task Deve_Buscar_Todos_Os_Produtos()
        {
            var produtosMock = _produtoFixture.ProdutoMock();

            var produtoRespository = new Mock<IProdutoRepository>();
            var marcaService = new Mock<IMarcaService>();

            produtoRespository.Setup(x => x.ObterTodos())
                .ReturnsAsync(produtosMock);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = await service.ObterTodos();

            Assert.Equal(produtosRetorno, produtosMock);
        }

        [Fact]
        public async Task Deve_Buscar_Produto_Por_Nome()
        {
            var produtosMock = _produtoFixture.ProdutoMock();

            var produtoRespository = new Mock<IProdutoRepository>();
            var marcaService = new Mock<IMarcaService>();
            produtoRespository.Setup(x => x.ObterPorNome(It.IsAny<string>()))
                .ReturnsAsync(produtosMock);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = await service.ObterPorNome(produtosMock.First().Descricao);

            Assert.Equal(produtosRetorno, produtosMock);
        }

        [Fact]
        public async Task Deve_Buscar_Produto_Por_Marca()
        {
            var produtosMock = _produtoFixture.ProdutoMock();
            var marcasMock = _produtoFixture.MarcasMock();

            var marcaService = new Mock<IMarcaService>();
            var produtoRespository = new Mock<IProdutoRepository>();

            marcaService.Setup(m => m.ObterPorNome(It.IsAny<string>()))
                .ReturnsAsync(marcasMock);

            produtoRespository.Setup(x => x.ObterPorCodigoMarca(It.IsAny<IEnumerable<int>>()))
                .ReturnsAsync(produtosMock);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = await service.ObterProdutosPorMarca(produtosMock.First().Descricao);

            Assert.Equal(produtosRetorno, produtosMock);
        }

        [Fact]
        public async Task Deve_Retornar_Produto_Usando_Filtro_De_Produto()
        {
            var produtosMock = _produtoFixture.ProdutoMock();
            FiltrosProduto.NomeProduto = produtosMock.First().Descricao;

            var marcaService = new Mock<IMarcaService>();
            var produtoRespository = new Mock<IProdutoRepository>();

            produtoRespository.Setup(x => x.ObterPorNome(It.IsAny<string>()))
                .ReturnsAsync(produtosMock);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = await service.ObterPorFitlro(FiltrosProduto);

            Assert.Equal(produtosRetorno, produtosMock);
        }

        [Fact]
        public async Task Deve_Retornar_Produto_Usando_Filtro_De_Marca()
        {
            var produtosMock = _produtoFixture.ProdutoMock();
            var marcasMock = _produtoFixture.MarcasMock();
            FiltrosProduto.NomeMarcaProduto = produtosMock.First().Marca.Descricao;

            var marcaService = new Mock<IMarcaService>();
            var produtoRespository = new Mock<IProdutoRepository>();

            marcaService.Setup(m => m.ObterPorNome(It.IsAny<string>()))
                .ReturnsAsync(marcasMock);

            produtoRespository.Setup(x => x.ObterPorCodigoMarca(It.IsAny<IEnumerable<int>>()))
                .ReturnsAsync(produtosMock);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = await service.ObterPorFitlro(FiltrosProduto);

            Assert.Equal(produtosRetorno, produtosMock);
        }

        [Fact]
        public async Task Deve_Retornar_Produto_Usando_Filtro_De_Produto_E_Marca()
        {
            var produtosMock = _produtoFixture.ProdutoMock();
            var marcasMock = _produtoFixture.MarcasMock();
            FiltrosProduto.NomeProduto = produtosMock.First().Descricao;
            FiltrosProduto.NomeMarcaProduto = produtosMock.First().Marca.Descricao;

            var marcaService = new Mock<IMarcaService>();
            var produtoRespository = new Mock<IProdutoRepository>();

            marcaService.Setup(m => m.ObterPorNome(It.IsAny<string>()))
                .ReturnsAsync(marcasMock);

            produtoRespository.Setup(x => x.ObterPorCodigoMarca(It.IsAny<IEnumerable<int>>()))
                .ReturnsAsync(produtosMock);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = await service.ObterPorFitlro(FiltrosProduto);

            Assert.Equal(produtosRetorno, produtosMock);
        }

        [Fact]
        public async Task Deve_Retornar_Produto_Usando_Sem_Filtro()
        {
            var produtosMock = _produtoFixture.ProdutoMock();

            var marcaService = new Mock<IMarcaService>();
            var produtoRespository = new Mock<IProdutoRepository>();

            produtoRespository.Setup(x => x.ObterTodos())
                .ReturnsAsync(produtosMock);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = await service.ObterPorFitlro(FiltrosProduto);

            Assert.Equal(produtosRetorno, produtosMock);
        }

        [Fact]
        public void Deve_Criar_Produto()
        {
            var produtosMock = _produtoFixture.ProdutoMock().First();

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
            var produtoMock = _produtoFixture.ProdutoMock().First();

            var marcaService = new Mock<IMarcaService>();
            var produtoRespository = new Mock<IProdutoRepository>();

            produtoRespository.Setup(x => x.ObterPorId(It.IsAny<int>()))
                .Returns(produtoMock);

            produtoRespository.Setup(x => x.Atualiza(It.IsAny<Produto>()))
                .Returns(true);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = service.Atualiza(produtoMock);

            Assert.True(produtosRetorno);
        }
        
        [Fact]
        public void Deve_Dar_Erro_Ao_Atualizar_Produto_E_Nao_Encontrar_ID()
        {
            var produtosMock = _produtoFixture.ProdutoMock();
            var mensagemErro = Produto.ProdutoNaoEncontrato;

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
        public void Deve_Dar_Erro_Ao_Atualizar_Produto()
        {
            var produtoMock = _produtoFixture.ProdutoMock().First();
            var mensagemErro = Produto.ProdutoNaoEncontrato;

            var marcaService = new Mock<IMarcaService>();
            var produtoRespository = new Mock<IProdutoRepository>();
            
            produtoRespository.Setup(x => x.ObterPorId(It.IsAny<int>()))
                .Returns(produtoMock);

            produtoRespository.Setup(x => x.Atualiza(It.IsAny<Produto>()))
                .Throws(new Exception(mensagemErro));

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            Assert.ThrowsAsync<Exception>(async () => service.Atualiza(produtoMock));
        }

        [Fact]
        public void Deve_Deletar_Produto()
        {
            var produtoMock = _produtoFixture.ProdutoMock().First();

            var marcaService = new Mock<IMarcaService>();
            var produtoRespository = new Mock<IProdutoRepository>();

            produtoRespository.Setup(x => x.ObterPorId(It.IsAny<int>()))
                .Returns(produtoMock);

            produtoRespository.Setup(x => x.Deleta(It.IsAny<Produto>()))
                .Returns(true);

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = service.Deleta(produtoMock);

            Assert.True(produtosRetorno);
        }
        
        [Fact]
        public void Deve_Dar_Erro_Ao_Deletar_Produto_E_Nao_Encontrar_ID()
        {
            var produtosMock = _produtoFixture.ProdutoMock();
            var mensagemErro = Produto.ProdutoNaoEncontrato;

            var marcaService = new Mock<IMarcaService>();
            var produtoRespository = new Mock<IProdutoRepository>();

            produtoRespository.Setup(x => x.Deleta(It.IsAny<Produto>()))
                .Throws(new NotFoundExepction(mensagemErro));

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            var produtosRetorno = Assert.ThrowsAsync<NotFoundExepction>(
                async () => service.Deleta(produtosMock.First()));

            Assert.Equal(mensagemErro, produtosRetorno.Result.Message);
        }
        
        [Fact]
        public void Deve_Dar_Erro_Ao_Deletar_Produto()
        {
            var produtoMock = _produtoFixture.ProdutoMock().First();
            var mensagemErro = Produto.ErroAoModificarProduto;

            var marcaService = new Mock<IMarcaService>();
            var produtoRespository = new Mock<IProdutoRepository>();

            produtoRespository.Setup(x => x.ObterPorId(It.IsAny<int>()))
                .Returns(produtoMock);

            produtoRespository.Setup(x => x.Deleta(It.IsAny<Produto>()))
                .Throws(new Exception(mensagemErro));

            var service = new ProdutoService(produtoRespository.Object, marcaService.Object);
            Assert.ThrowsAsync<Exception>(async () => service.Deleta(produtoMock));
        }
    }
}
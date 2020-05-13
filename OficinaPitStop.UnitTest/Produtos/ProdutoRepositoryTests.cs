using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OficinaPitStop.Entities.Produtos;
using OficinaPitStop.Repositories;
using OficinaPitStop.Repositories.Repository.Produtos;
using Xunit;

namespace OficinaPitStop.UnitTest.Produtos
{
    public class ProdutoRepositoryTests
    {
        [Fact]
        public async Task Deve_Retornar_Consultas_De_Produto()
        {
            var options = new DbContextOptionsBuilder<OficinaPitStopContext>()
                .UseInMemoryDatabase("Testes_Consulta_Produtos")
                .Options;

            using (var context = new OficinaPitStopContext(options))
            {
                PreencheProdutos(context);
                var produtoRepository = new ProdutoRepository(context);
                var produtos = await produtoRepository.ObterTodos();
                Assert.NotEmpty(produtos);

                var produto = produtos.First();

                var retornoPorId = await produtoRepository.ObterPorId(produto.Codigo);
                Assert.NotNull(retornoPorId);

                var retornoPorNome = await produtoRepository.ObterPorNome(produto.Descricao);
                Assert.NotEmpty(retornoPorNome);

                var codigoMarcas = new List<int>(new[] {produto.CodigoMarca});
                var retornoPorMarca = await produtoRepository.ObterPorCodigoMarca(codigoMarcas);
                Assert.NotEmpty(retornoPorMarca);
            }
        }
        
        [Fact]
        public async Task Deve_Adicionar_Atualizar_E_Deletar_Produto()
        {
            var options = new DbContextOptionsBuilder<OficinaPitStopContext>()
                .UseInMemoryDatabase("Testes_Modifica_Produto")
                .Options;

            using (var context = new OficinaPitStopContext(options))
            {
                //Cria
                var produtoRepository = new ProdutoRepository(context);
                var produto = CriaProduto(1);
                var retornoAdiciona = await produtoRepository.Adiciona(produto);
                Assert.True(retornoAdiciona);

                var retornoPorId = await produtoRepository.ObterPorId(produto.Codigo);
                Assert.Equal(retornoPorId, produto);
                Assert.Equal(produto.Preco, retornoPorId.Preco);
                Assert.Equal(produto.Quantidade, retornoPorId.Quantidade);
                
                //Atualiza
                var descricaoAntigaProduto = retornoPorId.Descricao;
                var novaDescricaoProduto = "Nova descrição produto!";
                produto.Descricao = novaDescricaoProduto;
                var retornoAtualiza = await produtoRepository.Atualiza(produto);
                Assert.True(retornoAtualiza);
                retornoPorId = await produtoRepository.ObterPorId(produto.Codigo);
                
                Assert.NotEqual(descricaoAntigaProduto, retornoPorId.Descricao);
                Assert.Equal(novaDescricaoProduto, retornoPorId.Descricao);
                
                //Deleta
                var retornoDelete = await produtoRepository.Deleta(produto);
                Assert.True(retornoDelete);
                
                retornoPorId = await produtoRepository.ObterPorId(produto.Codigo);
                Assert.Null(retornoPorId);
            }
        }

        private void PreencheProdutos(OficinaPitStopContext context)
        {
            var produtos = new[]
            {
                CriaProduto(1),
                CriaProduto(2)
            };

            context.Produtos.AddRange(produtos);
            context.SaveChanges();
        }

        private static Produto CriaProduto(int codigo)
        {
            return new Produto()
            {
                Codigo = codigo,
                Descricao = "Descricao produto",
                Preco = 1,
                Quantidade = 1,
                CodigoMarca = 1
            };
        }
    }
}
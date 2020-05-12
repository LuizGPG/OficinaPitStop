using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OficinaPitStop.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OficinaPitStop.Entities.Produtos;
using OficinaPitStop.Entities.Produtos.Marcas;
using OficinaPitStop.Repositories;

namespace OficinaPitStop.IntegrationTest

{
    public class IntegrationTest
    {
        protected readonly HttpClient Client;

        protected IntegrationTest()
        {
            
           
            
            
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(OficinaPitStopContext));
                        services.AddDbContext<OficinaPitStopContext>(options =>
                        {
                            options.UseInMemoryDatabase("DBMemory");
                        });
                    });
                });
            Client = appFactory.CreateClient();
            Client.BaseAddress = new Uri("https://localhost:5001/graphql");
            
            //-----------------------------------------

            var optionsMemory = new DbContextOptionsBuilder<OficinaPitStopContext>()
                .UseInMemoryDatabase("DBMemory")
                .Options;

            var context = new OficinaPitStopContext(optionsMemory);
            PreencheProdutos(context);
            PreencheMarca(context);
            
            
        }

        private void PreencheProdutos(OficinaPitStopContext context)
        {
            var produtos = new[]
            {
                new Produto()
                {
                    Codigo = 1,
                    Descricao = "Descricao produto 1",
                    Preco = 1,
                    Quantidade = 1,
                    CodigoMarca = 1
                },
                new Produto()
                {
                    Codigo = 2,
                    Descricao = "Descricao produto 2",
                    Preco = 2,
                    Quantidade = 2,
                    CodigoMarca = 2
                }
            };
            
            context.Produtos.AddRange(produtos);
            context.SaveChanges();
        }

        private void PreencheMarca(OficinaPitStopContext context)
        {
            var marcas = new[]
            {
                new Marca()
                {
                    CodigoMarca = 1,
                    Descricao = "Descricao marca 1"
                },
                new Marca()
                {
                    CodigoMarca = 2,
                    Descricao = "Descricao marca 2"
                }
            };
            context.Marca.AddRange(marcas);
            context.SaveChanges();
        }
        
    }
}
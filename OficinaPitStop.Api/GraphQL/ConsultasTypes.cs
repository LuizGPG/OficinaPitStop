using System.Collections.Generic;
using GraphQL.Types;
using OficinaPitStop.Api.GraphQL.Produtos.Marcas.Types;
using OficinaPitStop.Api.GraphQL.Produtos.Types;
using OficinaPitStop.Entities.Produtos;
using OficinaPitStop.Repositories.Abstractions.Repository.Produtos.Marcas;
using OficinaPitStop.Services.Abstractions.Produtos;

namespace OficinaPitStop.Api.GraphQL
{
    public class ConsultasTypes : ObjectGraphType
    {
        private readonly IProdutoService _produtoService;
        private readonly IMarcaRepository _marcaRepository;

        public ConsultasTypes(IProdutoService produtoService, IMarcaRepository marcaRepository)
        {
            _produtoService = produtoService;
            _marcaRepository = marcaRepository;
            
            ConsultasType();
        }

        private void ConsultasType()
        {
            ConsultaProdutosType();
            ConsultaMarcasTyoe();
        }

        private void ConsultaMarcasTyoe()
        {
            Field<ListGraphType<MarcaType>>(
                "marcas",
                resolve: context => _marcaRepository.ObtemTodasAsMarcas());
        }

        private void ConsultaProdutosType()
        {
            ProdutoType x = new ProdutoType(_marcaRepository);
            Field<ListGraphType<ProdutoType>>(
                "produtos",
                resolve: context => _produtoService.ObtemTodosProdutos());

            Field<ListGraphType<ProdutoType>>(
                "produto",
                arguments: new QueryArguments(MontaListaDeQueryArguments()),
                resolve: context =>
                {
                    var filtros = new FiltrosProduto();
                    filtros.NomeProduto = context.GetArgument<string>(FiltrosProduto.FiltroNomeProduto);
                    filtros.NomeMarcaProduto = context.GetArgument<string>(FiltrosProduto.FiltroNomeMarcaProduto);

                    return _produtoService.ObterProdutosPorFitlro(filtros);
                });
        }

        private static List<QueryArgument> MontaListaDeQueryArguments()
        {
            List<string> filtros = FiltrosProduto.Filtros;
            List<QueryArgument> listaDeQuery = new List<QueryArgument>();
            
            foreach (var filtro in filtros)
                listaDeQuery.Add(new QueryArgument<IdGraphType> {Name = filtro});

            return listaDeQuery;
        }
    }
}
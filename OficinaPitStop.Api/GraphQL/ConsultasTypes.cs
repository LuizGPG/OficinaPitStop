using System.Collections.Generic;
using GraphQL.Types;
using OficinaPitStop.Api.GraphQL.Produtos.Marcas.Types;
using OficinaPitStop.Api.GraphQL.Produtos.Types;
using OficinaPitStop.Entities.Filtros.Produtos;
using OficinaPitStop.Entities.Filtros.Produtos.Marcas;
using OficinaPitStop.Services.Abstractions.Produtos;
using OficinaPitStop.Services.Abstractions.Produtos.Marcas;

namespace OficinaPitStop.Api.GraphQL
{
    public class ConsultasTypes : ObjectGraphType
    {
        private readonly IProdutoService _produtoService;
        private readonly IMarcaService _marcaService;

        public ConsultasTypes(IProdutoService produtoService, IMarcaService marcaService)
        {
            _produtoService = produtoService;
            _marcaService = marcaService;

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
                resolve: context => _marcaService.ObterTodos());

            Field<ListGraphType<MarcaType>>(
                "marca",
                arguments: new QueryArguments(MontaListaDeQueryArguments(FiltrosMarca.Filtros)),
                resolve: context =>
                {
                    var filtros = new FiltrosMarca();
                    filtros.NomeMarca = context.GetArgument<string>(FiltrosMarca.FiltroNomeMarca);
                    return _marcaService.ObterPorNome(filtros.NomeMarca);
                });
        }

        private void ConsultaProdutosType()
        {
            Field<ListGraphType<ProdutoType>>(
                "produtos",
                resolve: context => _produtoService.ObterTodos());

            Field<ListGraphType<ProdutoType>>(
                "produto",
                arguments: new QueryArguments(MontaListaDeQueryArguments(FiltrosProduto.Filtros)),
                resolve: context =>
                {
                    var filtros = new FiltrosProduto();
                    filtros.NomeProduto = context.GetArgument<string>(FiltrosProduto.FiltroNomeProduto);
                    filtros.NomeMarcaProduto = context.GetArgument<string>(FiltrosProduto.FiltroNomeMarcaProduto);

                    return _produtoService.ObterPorFitlro(filtros);
                });
        }

        private static List<QueryArgument> MontaListaDeQueryArguments(List<string> filtros)
        {
            List<QueryArgument> listaDeQuery = new List<QueryArgument>();

            foreach (var filtro in filtros)
                listaDeQuery.Add(new QueryArgument<IdGraphType> {Name = filtro});

            return listaDeQuery;
        }
    }
}
using System.Collections.Generic;
using GraphQL.Types;
using OficinaPitStop.Entities;
using OficinaPitStop.Services.Abstractions.Produtos;

namespace OficinaPitStop.Api.GraphQL.Produtos.Types
{
    public class ProdutoConsultaType : ObjectGraphType
    {
        private readonly IProdutoService _produtoService;

        public ProdutoConsultaType(IProdutoService produtoService)
        {
            _produtoService = produtoService;
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
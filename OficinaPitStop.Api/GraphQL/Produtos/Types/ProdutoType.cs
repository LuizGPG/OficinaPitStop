using System.Collections.Generic;
using GraphQL.Types;
using OficinaPitStop.Api.GraphQL.Produtos.Marcas.Types;
using OficinaPitStop.Entities;
using OficinaPitStop.Entities.Produtos;
using OficinaPitStop.Repositories.Abstractions.Repository.Produtos.Marcas;
using OficinaPitStop.Services.Abstractions.Produtos;

namespace OficinaPitStop.Api.GraphQL.Produtos.Types
{
    public class ProdutoType : ObjectGraphType<Produto>
    {
        private readonly IProdutoService _produtoService;
        public ProdutoType(IMarcaRepository marcaRepository)
        {
            Field(p => p.Codigo).Description("Código do produto na base");
            Field(p => p.Descricao);
            Field(p => p.Quantidade).Description("Quantidade do produto no estoque.");
            Field(p => p.Preco).Description("Preco produto.");
            Field<MarcaType>(
                "marca",
                resolve: context => marcaRepository.ObtemMarcaPorId(context.Source.CodigoMarca));
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
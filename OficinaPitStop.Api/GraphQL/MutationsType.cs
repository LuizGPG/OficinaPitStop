using GraphQL.Types;
using OficinaPitStop.Api.GraphQL.Produtos.Types;
using OficinaPitStop.Entities.Produtos;
using OficinaPitStop.Services.Abstractions.Produtos;

namespace OficinaPitStop.Api.GraphQL
{
    public class MutationsType : ObjectGraphType
    {
        public MutationsType(IProdutoService produtoService)
        {
            FieldAsync<BooleanGraphType>(
                "create_produto",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<MutationProdutoType>> {Name = "create"}),
                resolve: async context =>
                {
                    var produto = context.GetArgument<Produto>("create");
                    return await context.TryAsyncResolve(
                        async c => produtoService.AdicionaProduto(produto));
                });
        }
        
    }
}
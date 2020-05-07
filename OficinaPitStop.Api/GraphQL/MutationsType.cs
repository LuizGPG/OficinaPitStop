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
            ProdutoMutations(produtoService);
        }

        private void ProdutoMutations(IProdutoService produtoService)
        {
            FieldAsync<BooleanGraphType>(
                "create_produto",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProdutoCreateType>> {Name = "create"}),
                resolve: async context =>
                {
                    var produto = context.GetArgument<Produto>("create");
                    return await context.TryAsyncResolve(
                        async c => produtoService.AdicionaProduto(produto));
                });
            
            FieldAsync<BooleanGraphType>(
                "update_produto",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProdutoUpdateType>> {Name = "update"}),
                resolve: async context =>
                {
                    var produto = context.GetArgument<Produto>("update");
                    return await context.TryAsyncResolve(
                        async c => produtoService.AtualizaProduto(produto));
                });
        }
    }
}
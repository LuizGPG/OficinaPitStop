using GraphQL.Types;
using OficinaPitStop.Api.GraphQL.Produtos.Marcas.Types;
using OficinaPitStop.Api.GraphQL.Produtos.Types;
using OficinaPitStop.Entities.Produtos;
using OficinaPitStop.Entities.Produtos.Marcas;
using OficinaPitStop.Services.Abstractions.Produtos;
using OficinaPitStop.Services.Abstractions.Produtos.Marcas;

namespace OficinaPitStop.Api.GraphQL
{
    public class MutationsType : ObjectGraphType
    {
        public MutationsType(IProdutoService produtoService, IMarcaService marcaService)
        {
            ProdutoMutations(produtoService);
            MarcaMutations(marcaService);
        }
        
        private void MarcaMutations(IMarcaService marcaService)
        {
            FieldAsync<BooleanGraphType>(
                "create_marca",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<MarcaCreateType>> {Name = "create"}),
                resolve: async context =>
                {
                    var marca = context.GetArgument<Marca>("create");
                    return await context.TryAsyncResolve(
                        async c => marcaService.Adiciona(marca));
                });
            
            FieldAsync<BooleanGraphType>(
                "update_marca",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<MarcaUpdateType>> {Name = "update"}),
                resolve: async context =>
                {
                    var marca = context.GetArgument<Marca>("update");
                    return await context.TryAsyncResolve(
                        async c => marcaService.Atualiza(marca));
                });
            
            FieldAsync<BooleanGraphType>(
                "delete_marca",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<MarcaDeleteType>> {Name = "delete"}),
                resolve: async context =>
                {
                    var marca = context.GetArgument<Marca>("delete");
                    return await context.TryAsyncResolve(
                        async c => marcaService.Deleta(marca));
                });
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
                        async c => produtoService.Adiciona(produto));
                });
            
            FieldAsync<BooleanGraphType>(
                "update_produto",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProdutoUpdateType>> {Name = "update"}),
                resolve: async context =>
                {
                    var produto = context.GetArgument<Produto>("update");
                    return await context.TryAsyncResolve(
                        async c => produtoService.Atualiza(produto));
                });
            
            FieldAsync<BooleanGraphType>(
                "delete_produto",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProdutoDeleteType>> {Name = "delete"}),
                resolve: async context =>
                {
                    var produto = context.GetArgument<Produto>("delete");
                    return await context.TryAsyncResolve(
                        async c => produtoService.Deleta(produto));
                });
        }
    }
}
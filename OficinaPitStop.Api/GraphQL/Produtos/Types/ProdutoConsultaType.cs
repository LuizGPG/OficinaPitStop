using GraphQL;
using GraphQL.Types;
using OficinaPitStop.Api.GraphQL.Produtos.Marcas.Types;
using OficinaPitStop.Repositories.Abstractions.Repository;
using OficinaPitStop.Repositories.Abstractions.Repository.Produtos.Marcas;
using OficinaPitStop.Repositories.Repository;
using OficinaPitStop.Services.Abstractions.Produtos;

namespace OficinaPitStop.Api.GraphQL.Produtos.Types
{
    public class ProdutoConsultaType : ObjectGraphType
    {
        private readonly IProdutoService _produtoService;
        private const string FiltroNomeProduto = "nome_produto";
        private const string FiltroNomeMarcaProduto = "marca_produto";
        public ProdutoConsultaType(IProdutoService produtoService)
        {
            _produtoService = produtoService;

            Field<ListGraphType<ProdutoType>>(
                "produtos",
                resolve: context => _produtoService.ObtemTodosProdutos());
            
            Field<ListGraphType<ProdutoType>>(
                "produto",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType>{Name = FiltroNomeProduto},
                    new QueryArgument<IdGraphType>{Name = FiltroNomeMarcaProduto}
                    ),
                resolve: context =>
                {
                    var nomeProduto = context.GetArgument<string>(FiltroNomeProduto);
                    var marcaProduto = context.GetArgument<string>(FiltroNomeMarcaProduto);

                    if (nomeProduto != null && marcaProduto != null)
                        return null;// implementar metodo filtrando por dois
                    
                    if(nomeProduto != null)
                        return _produtoService.ObtemProdutosPorNome(nomeProduto);

                    if (marcaProduto != null)
                        return _produtoService.ObterProdutosPorMarca(marcaProduto);
        
                    return null;
                });
        }
    }
}
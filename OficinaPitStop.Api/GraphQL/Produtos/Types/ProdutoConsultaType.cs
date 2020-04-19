using GraphQL.Types;
using OficinaPitStop.Repositories.Repository;

namespace OficinaPitStop.Api.GraphQL.Produtos.Types
{
    public class ProdutoConsultaType : ObjectGraphType
    {
        public ProdutoConsultaType(ProdutoRepository repository)
        {
            Field<ListGraphType<ProdutoType>>(
                "produtos",
                resolve: context => repository.ObtemTodosProdutos());
        }
    }
}
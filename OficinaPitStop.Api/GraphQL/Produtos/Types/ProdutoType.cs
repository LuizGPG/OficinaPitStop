using GraphQL.Instrumentation;
using GraphQL.Types;
using OficinaPitStop.Entities.Produtos;

namespace OficinaPitStop.Api.GraphQL.Produtos.Types
{
    public class ProdutoType : ObjectGraphType<Produto>
    {
        public ProdutoType()
        {
            Field(p => p.id);
            Field(p => p.descricao);
            Field(p => p.quantidade);
        }
    }
}
using GraphQL.Instrumentation;
using GraphQL.Types;
using OficinaPitStop.Entities.Produtos;

namespace OficinaPitStop.Api.GraphQL.Produtos.Types
{
    public class ProdutoType : ObjectGraphType<Produto>
    {
        public ProdutoType()
        {
            Field(p => p.Codigo);
            Field(p => p.Descricao);
            Field(p => p.Quantidade);
        }
    }
}
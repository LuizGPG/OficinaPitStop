using GraphQL.Types;
using OficinaPitStop.Entities.Produtos;

namespace OficinaPitStop.Api.GraphQL.Produtos.Types
{
    public class ProdutoDeleteType : InputObjectGraphType<Produto>
    {
        public ProdutoDeleteType()
        {
            Name = "delete_produto";
            Field(p => p.Codigo);
        }
    }
}
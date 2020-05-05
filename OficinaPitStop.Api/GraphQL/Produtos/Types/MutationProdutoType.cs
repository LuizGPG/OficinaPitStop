using GraphQL.Types;
using OficinaPitStop.Entities.Produtos;

namespace OficinaPitStop.Api.GraphQL.Produtos.Types
{
    public class MutationProdutoType : InputObjectGraphType<Produto>
    {
        public MutationProdutoType()
        {
            Name = "create";
            Field(p => p.Descricao);
            Field(p => p.Preco);
            Field(p => p.Quantidade);
            Field(p => p.CodigoMarca);
        }
    }
}
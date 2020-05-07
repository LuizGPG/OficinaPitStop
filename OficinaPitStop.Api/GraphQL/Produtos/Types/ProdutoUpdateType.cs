using GraphQL.Types;
using OficinaPitStop.Entities.Produtos;

namespace OficinaPitStop.Api.GraphQL.Produtos.Types
{
    public class ProdutoUpdateType : InputObjectGraphType<Produto>
    {
        public ProdutoUpdateType()
        {
            Name = "update_produto";
            Field(p => p.Codigo);
            Field(p => p.Descricao, true);
            Field(p => p.Preco, true);
            Field(p => p.Quantidade, true);
            Field(p => p.CodigoMarca, true);
        }
    }
}
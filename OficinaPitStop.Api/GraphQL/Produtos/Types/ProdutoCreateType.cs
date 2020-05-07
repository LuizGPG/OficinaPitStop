using GraphQL.Types;
using OficinaPitStop.Entities.Produtos;

namespace OficinaPitStop.Api.GraphQL.Produtos.Types
{
    public class ProdutoCreateType : InputObjectGraphType<Produto>
    {
        public ProdutoCreateType()
        {
            Name = "create_produto";
            Field(p => p.Codigo, true);
            Field(p => p.Descricao);
            Field(p => p.Preco);
            Field(p => p.Quantidade);
            Field(p => p.CodigoMarca, true);
        }
    }
}
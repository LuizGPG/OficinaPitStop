using GraphQL.Types;

namespace OficinaPitStop.Api.GraphQL.Produtos.Marcas.Types
{
    public class MarcaType : ObjectGraphType<Entities.Produtos.Marcas.Marca>
    {
        public MarcaType()
        {
            Field(f => f.CodigoMarca);
            Field(f => f.Descricao);
        }
    }
}
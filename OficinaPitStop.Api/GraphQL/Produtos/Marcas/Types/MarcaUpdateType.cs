using GraphQL.Types;
using OficinaPitStop.Entities.Produtos.Marcas;

namespace OficinaPitStop.Api.GraphQL.Produtos.Marcas.Types
{
    public class MarcaUpdateType : InputObjectGraphType<Marca>
    {
        public MarcaUpdateType()
        {
            Name = "update_marca";
            Field(p => p.CodigoMarca);
            Field(p => p.Descricao);
        }
    }
}
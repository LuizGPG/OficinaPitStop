using GraphQL.Types;
using OficinaPitStop.Entities.Produtos.Marcas;

namespace OficinaPitStop.Api.GraphQL.Produtos.Marcas.Types
{
    public class MarcaDeleteType : InputObjectGraphType<Marca>
    {
        public MarcaDeleteType()
        {
            Name = "delete_marca";
            Field(p => p.CodigoMarca);
        }
    }
}
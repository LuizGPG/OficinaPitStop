using GraphQL.Types;
using OficinaPitStop.Entities.Produtos.Marcas;

namespace OficinaPitStop.Api.GraphQL.Produtos.Marcas.Types
{
    public class MarcaCreateType : InputObjectGraphType<Marca>
    {
        public MarcaCreateType()
        {
            Name = "create_marca";
            Field(p => p.CodigoMarca, true);
            Field(p => p.Descricao);
        }
    }
}
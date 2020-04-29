using GraphQL;
using GraphQL.Types;
using OficinaPitStop.Api.GraphQL.Produtos.Marcas.Types;

namespace OficinaPitStop.Api.GraphQL.Produtos.Marcas.Schemas
{
    public class MarcaSchema : Schema
    {
        public MarcaSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<MarcaConsultaType>();
        }
    }
}
using GraphQL;
using GraphQL.Types;
using OficinaPitStop.Api.GraphQL.Produtos.Types;

namespace OficinaPitStop.Api.GraphQL
{
    public class OficinaPitStopSchema : Schema
    {
        public OficinaPitStopSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ConsultasTypes>();
        }
    }
}
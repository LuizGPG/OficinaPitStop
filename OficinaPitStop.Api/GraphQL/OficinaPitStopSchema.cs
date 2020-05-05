using GraphQL;
using GraphQL.Types;

namespace OficinaPitStop.Api.GraphQL
{
    public class OficinaPitStopSchema : Schema
    {
        public OficinaPitStopSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ConsultasTypes>();
            Mutation = resolver.Resolve<MutationsType>();
        }
    }
}
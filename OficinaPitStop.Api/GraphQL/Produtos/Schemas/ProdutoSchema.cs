using GraphQL;
using GraphQL.Types;
using OficinaPitStop.Api.GraphQL.Produtos.Types;

namespace OficinaPitStop.Api.GraphQL.Produtos.Schemas
{
    public class ProdutoSchema : Schema
    {
        public ProdutoSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ProdutoConsultaType>();
        }
    }
}
using GraphQL.Types;
using OficinaPitStop.Repositories.Abstractions.Repository.Produtos.Marcas;

namespace OficinaPitStop.Api.GraphQL.Produtos.Marcas.Types
{
    public class MarcaConsultaType : ObjectGraphType
    {
        public MarcaConsultaType(IMarcaRepository repository)
        {
            Field<ListGraphType<MarcaType>>(
                "marcas",
                resolve: context => repository.ObterTodos());
        }
    }
}
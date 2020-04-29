using GraphQL.Types;
using OficinaPitStop.Repositories.Abstractions.Repository.Produtos.Marcas;

namespace OficinaPitStop.Api.GraphQL.Produtos.Marcas.Types
{
    public class MarcaConsultaType : ObjectGraphType
    {
        private readonly IMarcaRepository _repository;
        
        public MarcaConsultaType(IMarcaRepository repository)
        {
            _repository = repository;
            Field<ListGraphType<MarcaType>>(
                "marcas",
                resolve: context => _repository.ObtemTodasAsMarcas());
        }
    }
}
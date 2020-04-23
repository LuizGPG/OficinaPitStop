using GraphQL.Types;
using OficinaPitStop.Repositories.Abstractions.Repository;
using OficinaPitStop.Repositories.Repository;

namespace OficinaPitStop.Api.GraphQL.Produtos.Types
{
    public class ProdutoConsultaType : ObjectGraphType
    {
        private readonly IProdutoRepository _repository;
            
        public ProdutoConsultaType(IProdutoRepository repository)
        {
            _repository = repository;
            Field<ListGraphType<ProdutoType>>(
                "produtos",
                resolve: context => _repository.ObtemTodosProdutos());
        }
    }
}
using GraphQL;
using GraphQL.Types;
using OficinaPitStop.Api.GraphQL.Produtos.Marcas.Types;
using OficinaPitStop.Repositories.Abstractions.Repository;
using OficinaPitStop.Repositories.Abstractions.Repository.Produtos.Marcas;
using OficinaPitStop.Repositories.Repository;

namespace OficinaPitStop.Api.GraphQL.Produtos.Types
{
    public class ProdutoConsultaType : ObjectGraphType
    {
        private readonly IProdutoRepository _repository;
        private const string FiltroNomeProduto = "nome_produto";
        private const string FiltroNomeMarcaProduto = "marca_produto";
        public ProdutoConsultaType(IProdutoRepository repository)
        {
            _repository = repository;

            Field<ListGraphType<ProdutoType>>(
                "produtos",
                resolve: context => _repository.ObtemTodosProdutos());
            
            Field<ListGraphType<ProdutoType>>(
                "produto",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType>{Name = FiltroNomeProduto},
                    new QueryArgument<IdGraphType>{Name = FiltroNomeMarcaProduto}
                    ),
                resolve: context =>
                {
                    var nomeProduto = context.GetArgument<string>(FiltroNomeProduto);
                    var marcaProduto = context.GetArgument<string>(FiltroNomeMarcaProduto);

                    if (nomeProduto != null && marcaProduto != null)
                        return null;// implementar metodo filtrando por dois
                    
                    if(nomeProduto != null)
                        return _repository.ObtemProdutosPorNome(nomeProduto);

                    if (marcaProduto != null)
                        return _repository.ObterProdutosPorMarca(marcaProduto);
        
                    return null;
                });
        }
    }
}
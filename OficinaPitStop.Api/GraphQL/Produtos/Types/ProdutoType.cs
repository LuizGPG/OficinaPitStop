using GraphQL.Types;
using OficinaPitStop.Api.GraphQL.Produtos.Marcas.Types;
using OficinaPitStop.Entities.Produtos;
using OficinaPitStop.Repositories.Abstractions.Repository.Produtos.Marcas;
using OficinaPitStop.Repositories.Repository.Produtos.Marcas;

namespace OficinaPitStop.Api.GraphQL.Produtos.Types
{
    public class ProdutoType : ObjectGraphType<Produto>
    {
        public ProdutoType(IMarcaRepository marcaRepository)
        {
            Field(p => p.Codigo).Description("Código do produto na base");
            Field(p => p.Descricao);
            Field(p => p.Quantidade).Description("Quantidade do produto no estoque.");
            Field(p => p.Preco).Description("Preco produto.");
            Field<MarcaType>(
                "marca",
                resolve: context => marcaRepository.ObtemMarcaPorId(context.Source.CodigoMarca));
        }
    }
}
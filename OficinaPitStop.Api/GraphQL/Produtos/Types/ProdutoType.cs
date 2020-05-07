using GraphQL.Types;
using OficinaPitStop.Api.GraphQL.Produtos.Marcas.Types;
using OficinaPitStop.Entities.Produtos;
using OficinaPitStop.Services.Abstractions.Produtos.Marcas;

namespace OficinaPitStop.Api.GraphQL.Produtos.Types
{
    public class ProdutoType : ObjectGraphType<Produto>
    {
        public ProdutoType(IMarcaService marcaService)
        {
            Field(p => p.Codigo).Description("Código do produto na base");
            Field(p => p.Descricao);
            Field(p => p.Quantidade).Description("Quantidade do produto no estoque.");
            Field(p => p.Preco).Description("Preco produto.");
            Field<MarcaType>(
                "marca",
                resolve: context => marcaService.ObterPorId(context.Source.CodigoMarca));
        }

    }
}
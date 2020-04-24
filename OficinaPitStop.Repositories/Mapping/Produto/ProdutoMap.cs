using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OficinaPitStop.Repositories.Models.Produtos;

namespace OficinaPitStop.Repositories.Mapping.Produto
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.HasKey(e => e.id);
            
        }
    }
}
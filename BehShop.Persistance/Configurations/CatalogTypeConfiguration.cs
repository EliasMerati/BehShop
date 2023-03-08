using BehShop.Domain.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BehShop.Persistance.Configurations
{
    internal class CatalogTypeConfiguration : IEntityTypeConfiguration<CatalogType>
    {
        public void Configure(EntityTypeBuilder<CatalogType> builder)
        {
            builder.Property(ct => ct.Type)    
                .IsRequired()
                .HasMaxLength(100);
        }
    }

}

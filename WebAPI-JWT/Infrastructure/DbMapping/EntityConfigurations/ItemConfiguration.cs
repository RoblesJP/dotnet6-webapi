using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DbMapping.EntityConfigurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(item => item.Id);

            builder.Property(item => item.Id).HasColumnName("id");
            builder.Property(item => item.Name).HasColumnName("name");
            builder.Property(item => item.Price100gr).HasColumnName("price_100gr");
            builder.Property(item => item.PriceKg).HasColumnName("price_kg");
            builder.Property(item => item.CategoryId).HasColumnName("id_category");

            builder.HasOne(item => item.Category)
                   .WithMany();
        }
    }
}
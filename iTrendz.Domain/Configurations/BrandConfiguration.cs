using iTrendz.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iTrendz.Domain.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasBaseType<User>();

        builder.HasMany(brand => brand.Campaigns)
            .WithOne(campaign => campaign.Brand)
            .HasForeignKey("BrandId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
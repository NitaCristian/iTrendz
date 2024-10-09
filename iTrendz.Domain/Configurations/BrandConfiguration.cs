using iTrendz.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iTrendz.Domain.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasBaseType<User>();

        // TODO Figure this one out
        builder.HasMany(brand => brand.Campaigns)
            .WithOne(campaign => campaign.Brand)
            .HasForeignKey(campaign => campaign.Brand.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
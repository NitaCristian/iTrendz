using iTrendz.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iTrendz.Domain.Configurations;

public class ContentPricingConfiguration : IEntityTypeConfiguration<ContentPricing>
{
    public void Configure(EntityTypeBuilder<ContentPricing> builder)
    {
        builder.HasKey(cp => cp.Id);

        builder.HasOne(cp => cp.Influencer)
            .WithMany(i => i.Pricings)
            .HasForeignKey("InfluencerId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
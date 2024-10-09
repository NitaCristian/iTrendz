using iTrendz.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iTrendz.Domain.Configurations;

public class ContentRequirementConfiguration : IEntityTypeConfiguration<ContentRequirement>
{
    public void Configure(EntityTypeBuilder<ContentRequirement> builder)
    {
        builder.HasKey(cr => cr.Id);

        builder.HasOne(cr => cr.Campaign)
            .WithMany(c => c.Requirements)
            .HasForeignKey("CampaignId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
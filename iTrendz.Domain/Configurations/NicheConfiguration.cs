using iTrendz.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iTrendz.Domain.Configurations;

public class NicheConfiguration : IEntityTypeConfiguration<Niche>
{
    public void Configure(EntityTypeBuilder<Niche> builder)
    {
        builder.ToTable("Niches");

        builder.HasKey(n => n.Id);

        builder.Property(n => n.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(n => n.Users)
            .WithMany(u => u.Niches)
            .UsingEntity<Dictionary<string, object>>(
                "UserNiche",
                j => j.HasOne<User>().WithMany().HasForeignKey("UserId"),
                j => j.HasOne<Niche>().WithMany().HasForeignKey("NicheId")
            );

        builder.HasMany(n => n.Campaigns)
            .WithMany(c => c.Niches)
            .UsingEntity<Dictionary<string, object>>(
                "CampaignNiche",
                j => j.HasOne<Campaign>().WithMany().HasForeignKey("CampaignId"),
                j => j.HasOne<Niche>().WithMany().HasForeignKey("NicheId")
            );
    }
}
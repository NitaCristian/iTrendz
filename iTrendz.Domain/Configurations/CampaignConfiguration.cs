using iTrendz.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iTrendz.Domain.Configurations;

public class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
{
    public void Configure(EntityTypeBuilder<Campaign> builder)
    {
        builder.ToTable("Campaigns");

        builder.HasKey(campaign => campaign.Id);

        builder.Property(campaign => campaign.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(campaign => campaign.Description)
            .HasMaxLength(2000);

        builder.Property(campaign => campaign.ImageUrl)
            .HasMaxLength(500);

        builder.Property(campaign => campaign.Budget)
            .HasColumnType("decimal(18,2)");

        builder.Property(campaign => campaign.ApplicationDeadline)
            .IsRequired();

        builder.Property(campaign => campaign.Type)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(campaign => campaign.State)
            .HasConversion<string>()
            .IsRequired();
        
        // TODO figure this one out
        builder.HasMany(campaign => campaign.Transactions)
            .WithOne(transaction => transaction.Campaign)
            .HasForeignKey(transaction => transaction.Campaign.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(campaign => campaign.Contracts)
            .WithOne(contract => contract.Campaign)
            .HasForeignKey(contract => contract.Campaign.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(campaign => campaign.Requirements)
            .WithOne(requirement => requirement.Campaign)
            .HasForeignKey(requirement => requirement.Campaign.Id)
            .OnDelete(DeleteBehavior.Cascade);
        
        // TODO here with niches
        builder.HasMany(c => c.Niches)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "CampaignNiche",
                j => j.HasOne<Niche>().WithMany().HasForeignKey("NicheId"),
                j => j.HasOne<Campaign>().WithMany().HasForeignKey("CampaignId")
            );

        builder.HasMany(c => c.Logs)
            .WithOne(l => l.Campaign)
            .HasForeignKey(l => l.Campaign.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
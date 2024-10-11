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

        builder.HasOne(c => c.Brand)
            .WithMany(b => b.Campaigns)
            .HasForeignKey("BrandId")
            .IsRequired();
        
        builder.Property(campaign => campaign.Budget)
            .HasColumnType("decimal(18,2)");

        builder.HasMany(campaign => campaign.Transactions)
            .WithOne(transaction => transaction.Campaign)
            .HasForeignKey("CampaignId")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(campaign => campaign.Type)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(campaign => campaign.State)
            .HasConversion<string>()
            .IsRequired();
        
        builder.Property(campaign => campaign.ApplicationDeadline)
            .IsRequired();

        builder.OwnsOne(c => c.Period, p =>
        {
            p.Property(pe => pe.StartDate).HasColumnName("PeriodStartDate").IsRequired();
            p.Property(pe => pe.EndDate).HasColumnName("PeriodEndDate").IsRequired();
            p.Ignore(pe => pe.Duration); 
        });

        builder.OwnsOne(c => c.Criteria, qc =>
        {
            qc.Property(q => q.MinFollowerCount).IsRequired();
            qc.Property(q => q.AverageViews).IsRequired();
            qc.Property(q => q.MinEngagementRate).IsRequired();

            qc.HasOne(q => q.TargetLocation)
                .WithMany()
                .IsRequired(false);
        });

        builder.HasMany(campaign => campaign.Contracts)
            .WithOne(contract => contract.Campaign)
            .HasForeignKey("CampaignId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(campaign => campaign.Requirements)
            .WithOne(requirement => requirement.Campaign)
            .HasForeignKey("CampaignId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Niches)
            .WithMany(n => n.Campaigns)
            .UsingEntity<Dictionary<string, object>>(
                "CampaignNiche",
                j => j.HasOne<Niche>().WithMany().HasForeignKey("NicheId"),
                j => j.HasOne<Campaign>().WithMany().HasForeignKey("CampaignId")
            );

        builder.HasMany(c => c.Logs)
            .WithOne(l => l.Campaign)
            .HasForeignKey("CampaignId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Ignore(c => c.Metrics);
    }
}
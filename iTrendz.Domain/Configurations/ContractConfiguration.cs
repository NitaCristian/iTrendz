using iTrendz.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iTrendz.Domain.Configurations;

public class ContractConfiguration : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.ToTable("Contracts");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Details)
            .IsRequired()
            .HasMaxLength(2000);

        builder.Property(c => c.SignedOnDate)
            .IsRequired();

        builder.Property(c => c.State)
            .HasConversion<string>()
            .IsRequired();

        builder.HasOne(c => c.Influencer)
            .WithMany(i => i.Contracts)
            .HasForeignKey("InfluencerId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c => c.Campaign)
            .WithMany(camp => camp.Contracts)
            .HasForeignKey("CampaignId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Posts)
            .WithOne(p => p.Contract)
            .HasForeignKey("ContractId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.AgreedContent)
            .WithOne(ca => ca.Contract)
            .HasForeignKey("ContractId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
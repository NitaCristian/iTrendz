using iTrendz.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iTrendz.Domain.Configurations;

public class ActionLogConfiguration : IEntityTypeConfiguration<ActionLog>
{
    public void Configure(EntityTypeBuilder<ActionLog> builder)
    {
        builder.ToTable("ActionLogs");

        builder.HasKey(al => al.Id);

        builder.HasOne(al => al.Campaign)
            .WithMany(c => c.Logs)
            .HasForeignKey("CampaignId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(al => al.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(al => al.Description)
            .HasMaxLength(500);

        builder.Property(al => al.Timestamp)
            .IsRequired();

        builder.Property(al => al.Type)
            .HasConversion<string>()
            .IsRequired();
    }
}
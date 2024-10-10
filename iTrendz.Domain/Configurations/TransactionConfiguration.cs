using iTrendz.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iTrendz.Domain.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transactions");

        builder.HasKey(transaction => transaction.Id);

        builder.HasOne(t => t.Campaign)
            .WithMany(c => c.Transactions)
            .HasForeignKey("CampaignId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(t => t.Amount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(t => t.Type)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(t => t.Date)
            .IsRequired();

        builder.Property(t => t.Notes)
            .HasMaxLength(1000);
    }
}
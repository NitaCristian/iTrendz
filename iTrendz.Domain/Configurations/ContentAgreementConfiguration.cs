using iTrendz.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iTrendz.Domain.Configurations;

public class ContentAgreementConfiguration : IEntityTypeConfiguration<ContentAgreement>
{
    public void Configure(EntityTypeBuilder<ContentAgreement> builder)
    {
        builder.ToTable("ContentAgreements");

        builder.HasKey(ca => ca.Id);

        builder.Property(ca => ca.ContentType)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(ca => ca.Platform)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(ca => ca.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(ca => ca.Description)
            .HasMaxLength(1000);

        builder.HasOne(ca => ca.Contract)
            .WithMany(c => c.AgreedContent)
            .HasForeignKey("ContractId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
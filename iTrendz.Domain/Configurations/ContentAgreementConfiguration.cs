using iTrendz.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iTrendz.Domain.Configurations;

public class ContentAgreementConfiguration : IEntityTypeConfiguration<ContentAgreement>
{
    public void Configure(EntityTypeBuilder<ContentAgreement> builder)
    {
        builder.HasOne(ca => ca.Contract)
            .WithMany(c => c.AgreedContent)
            .HasForeignKey("ContractId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
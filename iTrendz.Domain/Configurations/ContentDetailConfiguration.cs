using iTrendz.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iTrendz.Domain.Configurations;

public class ContentDetailConfiguration : IEntityTypeConfiguration<ContentDetail>
{
    public void Configure(EntityTypeBuilder<ContentDetail> builder)
    {
        builder.ToTable("ContentDetails");

        builder.HasDiscriminator<string>("ContentDetailType")
            .HasValue<ContentPricing>("Pricing")
            .HasValue<ContentRequirement>("Requirement")
            .HasValue<ContentAgreement>("Agreement");

        builder.HasKey(cd => cd.Id);

        builder.HasOne(cd => cd.ContentType)
            .WithMany()
            .HasForeignKey("ContentTypeId")
            .IsRequired();

        builder.HasOne(cd => cd.Platform)
            .WithMany()
            .HasForeignKey("PlatformId")
            .IsRequired();

        builder.Property(cd => cd.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(cd => cd.Description)
            .HasMaxLength(500);
    }
}
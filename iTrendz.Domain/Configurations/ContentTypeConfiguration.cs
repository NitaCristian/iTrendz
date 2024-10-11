using iTrendz.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iTrendz.Domain.Configurations;

public class ContentTypeConfiguration : IEntityTypeConfiguration<ContentType>
{
    public void Configure(EntityTypeBuilder<ContentType> builder)
    {
        builder.ToTable("ContentTypes");

        builder.HasKey(ct => ct.Id);

        builder.Property(ct => ct.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}
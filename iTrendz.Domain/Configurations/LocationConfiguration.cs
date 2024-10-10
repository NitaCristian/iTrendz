using iTrendz.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iTrendz.Domain.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("Locations");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.City)
            .HasMaxLength(100)
            .IsUnicode(false);

        builder.Property(l => l.State)
            .HasMaxLength(100)
            .IsUnicode(false);

        builder.Property(l => l.Country)
            .IsRequired()
            .HasMaxLength(100)
            .IsUnicode(false);
    }
}
using iTrendz.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iTrendz.Domain.Configurations;

public class NicheConfiguration : IEntityTypeConfiguration<Niche>
{
    public void Configure(EntityTypeBuilder<Niche> builder)
    {
        builder.ToTable("Niches");

        builder.HasKey(n => n.Id);

        builder.Property(n => n.Name)
            .IsRequired()
            .HasMaxLength(100);

        // Configure many-to-many relationships if necessary
        // e.g., with Users and Campaigns
    }
}
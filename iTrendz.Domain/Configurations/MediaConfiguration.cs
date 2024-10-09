using iTrendz.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iTrendz.Domain.Configurations;

public class MediaConfiguration : IEntityTypeConfiguration<Media>
{
    public void Configure(EntityTypeBuilder<Media> builder)
    {
        builder.ToTable("Media");
        
        builder.HasKey(media => media.Id);
        
        builder.Property(media => media.Title)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(media => media.Url)
            .IsRequired()
            .HasMaxLength(500);
        
        builder.HasDiscriminator<string>("MediaType")
            .HasValue<Video>("Video")
            .HasValue<Photo>("Photo");
    }
}
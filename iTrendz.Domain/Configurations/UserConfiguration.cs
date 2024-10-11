using iTrendz.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iTrendz.Domain.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(user => user.Id);

        builder.Property(user => user.ImageUrl)
            .HasMaxLength(500);

        builder.Property(user => user.WebsiteUrl)
            .HasMaxLength(500);

        builder.Property(user => user.ContactEmail)
            .HasMaxLength(255);

        builder.Property(user => user.Rating)
            .HasDefaultValue(0.0);

        builder.Property(user => user.RefreshToken)
            .HasMaxLength(500);

        builder.HasDiscriminator<string>("UserType")
            .HasValue<Influencer>("Influencer")
            .HasValue<Brand>("Brand");

        builder.HasOne(user => user.Location)
            .WithMany()
            .HasForeignKey("LocationId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(user => user.Niches)
            .WithMany(niche => niche.Users)
            .UsingEntity<Dictionary<string, object>>(
                "UserNiche",
                j => j.HasOne<Niche>().WithMany().HasForeignKey("NicheId"),
                j => j.HasOne<User>().WithMany().HasForeignKey("UserId")
            );

        builder.HasMany(user => user.Platforms)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "UserPlatform",
                j => j.HasOne<Platform>().WithMany().HasForeignKey("PlatformId"),
                j => j.HasOne<User>().WithMany().HasForeignKey("UserId")
            );
    }
}
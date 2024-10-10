﻿using System.Text.Json;
using iTrendz.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iTrendz.Domain.Configurations;

public class InfluencerConfiguration : IEntityTypeConfiguration<Influencer>
{
    public void Configure(EntityTypeBuilder<Influencer> builder)
    {
        builder.HasBaseType<User>();

        builder.Property(i => i.Age)
            .IsRequired();

        builder.Ignore(i => i.Metrics);

        builder.HasMany(i => i.Pricings)
            .WithOne(p => p.Influencer)
            .HasForeignKey("InfluencerId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(i => i.Contracts)
            .WithOne(c => c.Influencer)
            .HasForeignKey("InfluencerId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
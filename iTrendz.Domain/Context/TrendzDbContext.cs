using iTrendz.Domain.Fakers;
using iTrendz.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iTrendz.Domain.Context;

public class TrendzDbContext(DbContextOptions<TrendzDbContext> options)
    : IdentityDbContext<User, IdentityRole<int>, int>(options)
{
    // public DbSet<User> Users { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Influencer> Influencers { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<Contract> Contracts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .ToTable("Users")
            .HasDiscriminator<string>("UserType")
            .HasValue<User>("User")
            .HasValue<Brand>("Brand")
            .HasValue<Influencer>("Influencer");

        modelBuilder.Entity<Brand>()
            .HasMany(b => b.Campaigns)
            .WithOne(c => c.Brand)
            .HasForeignKey(c => c.BrandId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Influencer>()
            .HasMany(i => i.Contracts)
            .WithOne(c => c.Influencer)
            .HasForeignKey(c => c.InfluencerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Campaign>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Campaign>()
            .HasOne(c => c.Brand)
            .WithMany(b => b.Campaigns)
            .HasForeignKey(c => c.BrandId);

        modelBuilder.Entity<Campaign>()
            .Property(c => c.StartTime)
            .HasColumnType("date");

        modelBuilder.Entity<Campaign>()
            .Property(c => c.DateTime)
            .HasColumnType("date");

        modelBuilder.Entity<Contract>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Contract>()
            .HasOne(c => c.Influencer)
            .WithMany(i => i.Contracts)
            .HasForeignKey(c => c.InfluencerId);

        modelBuilder.Entity<Contract>()
            .HasOne(c => c.Campaign)
            .WithMany(ca => ca.Contracts)
            .HasForeignKey(c => c.CampaignId);

        modelBuilder.Entity<Contract>()
            .Property(c => c.SignedDate)
            .HasColumnType("date");

        var uniqueIdGenerator = new UniqueIdGenerator();
        var brandFaker = new BrandFaker(uniqueIdGenerator);
        var influencerFaker = new InfluencerFaker(uniqueIdGenerator);
        var campaignFaker = new CampaignFaker();
        var contractFaker = new ContractFaker();

        var brands = brandFaker.Generate(10);
        var influencers = influencerFaker.Generate(10);
        var campaigns = campaignFaker.Generate(10);
        var contracts = contractFaker.Generate(10);

        foreach (var campaign in campaigns)
        {
            campaign.BrandId = brands[new Random().Next(brands.Count)].Id;
        }

        foreach (var contract in contracts)
        {
            contract.InfluencerId = influencers[new Random().Next(influencers.Count)].Id;
            contract.CampaignId = campaigns[new Random().Next(campaigns.Count)].Id;
        }

        modelBuilder.Entity<Brand>().HasData(brands);
        modelBuilder.Entity<Influencer>().HasData(influencers);
        modelBuilder.Entity<Campaign>().HasData(campaigns);
        modelBuilder.Entity<Contract>().HasData(contracts);
    }
}
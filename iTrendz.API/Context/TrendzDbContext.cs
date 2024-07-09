using iTrendz.Api.Authentication;
using iTrendz.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iTrendz.API.Context;

public class TrendzDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    public TrendzDbContext(DbContextOptions<TrendzDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Influencer> Influencers { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<Contract> Contracts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.Entity<Campaign>()
        //     .HasOne(c => c.Brand)
        //     .WithMany(u => u.Campaigns)
        //     .HasForeignKey(c => c.BrandId)
        //     .IsRequired();
        //
        // modelBuilder.Entity<User>()
        //     .HasMany(u => u.Campaigns)
        //     .WithOne(c => c.Brand)
        //     .HasForeignKey(c => c.BrandId)
        //     .OnDelete(DeleteBehavior.Cascade);
    }
}
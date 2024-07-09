using iTrendz.Api.Authentication;
using iTrendz.Api.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iTrendz.Api.DataAccess.Context;

public class TrendzDbContext : IdentityDbContext<TrendzUser, IdentityRole<int>, int>
{
    public TrendzDbContext(DbContextOptions<TrendzDbContext> options) : base(options)
    {
    }

    public DbSet<TrendzUser> TrendzUsers { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<Contract> Contracts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Campaign>()
            .HasOne(c => c.Brand)
            .WithMany(u => u.Campaigns)
            .HasForeignKey(c => c.BrandId)
            .IsRequired();

        modelBuilder.Entity<TrendzUser>()
            .HasMany(u => u.Campaigns)
            .WithOne(c => c.Brand)
            .HasForeignKey(c => c.BrandId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
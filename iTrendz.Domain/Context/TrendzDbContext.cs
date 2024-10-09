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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrendzDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
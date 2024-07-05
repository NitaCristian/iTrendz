using iTrendz.Api.Authentication;
using iTrendz.Api.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iTrendz.Api.DataAccess.Context;

public class ApplicationContext : IdentityDbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public required DbSet<ApplicationUser> ApplicationUsers;
    public required DbSet<Campaign> Campaigns;
}
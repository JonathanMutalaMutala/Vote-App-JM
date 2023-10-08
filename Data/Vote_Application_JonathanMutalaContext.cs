using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vote_Application_JonathanMutala.Models;

namespace Vote_Application_JonathanMutala.Data;

public class Vote_Application_JonathanMutalaContext : IdentityDbContext<User,Role,string>
{
    public Vote_Application_JonathanMutalaContext(DbContextOptions<Vote_Application_JonathanMutalaContext> options)
        : base(options)
    {
    }


 
    public DbSet<Election> Elections { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Election>().ToTable("Election");

        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}

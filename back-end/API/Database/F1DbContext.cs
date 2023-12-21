using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace API.Database;

public class F1DbContext : IdentityDbContext<IdentityUser>
{
    public F1DbContext(DbContextOptions<F1DbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Lap> Laps { get; set; }
}
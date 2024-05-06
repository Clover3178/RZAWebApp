using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RZAWebApp.Models;

namespace RZAWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RZAWebApp.Models.Bookings> Bookings { get; set; } = default!;
        public DbSet<RZAWebApp.Models.Articles> Articles { get; set; } = default!;
    }
}

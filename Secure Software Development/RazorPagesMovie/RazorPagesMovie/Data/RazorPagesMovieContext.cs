using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Data
{
    public class RazorPagesMovieContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public RazorPagesMovieContext(DbContextOptions<RazorPagesMovieContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AuditRecord> AuditRecords { get; set; }
    }
}
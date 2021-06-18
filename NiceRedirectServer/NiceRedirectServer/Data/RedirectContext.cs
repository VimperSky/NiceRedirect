using Microsoft.EntityFrameworkCore;
using NiceRedirectServer.Models;

namespace NiceRedirectServer.Data
{
    public class RedirectContext: DbContext
    {
        public DbSet<Redirect> Redirects { get; init; }
        
        public RedirectContext(DbContextOptions<RedirectContext> options) : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Redirect>().ToTable("Redirect");
        }
    }
}
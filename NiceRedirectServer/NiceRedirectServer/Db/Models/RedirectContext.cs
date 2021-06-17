using Microsoft.EntityFrameworkCore;

namespace NiceRedirectServer.Db.Models
{
    public class RedirectContext: DbContext
    {
        public DbSet<Redirect> Redirects { get; set; }
        
    }
}
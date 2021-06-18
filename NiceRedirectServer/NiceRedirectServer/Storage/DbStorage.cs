using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NiceRedirectServer.Data;
using NiceRedirectServer.Models;

namespace NiceRedirectServer.Storage
{
    public class DbStorage : IStorage
    {
        private readonly RedirectContext _redirectContext;

        public DbStorage(RedirectContext redirectContext)
        {
            _redirectContext = redirectContext;
        }

        public async Task<Redirect> GetRedirect(string key)
        {
            return await _redirectContext.Redirects.FirstOrDefaultAsync(x => x.Key == key);
        }

        public async Task AddRedirect(Redirect redirect)
        {
            _redirectContext.Redirects.Add(redirect);
            await _redirectContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteRedirect(string key)
        {
            var redirect = await GetRedirect(key);
            if (redirect is null)
                return false;
            
            _redirectContext.Redirects.Remove(redirect);
            await _redirectContext.SaveChangesAsync();
            return true;
        }

        public async Task<Redirect[]> GetRedirects()
        {
            var redirects = await _redirectContext.Redirects.ToArrayAsync();
            return redirects;
        }
    }
}
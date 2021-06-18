using System.Threading.Tasks;
using NiceRedirectServer.Models;

namespace NiceRedirectServer.Storage
{
    public interface IStorage
    {
        Task<Redirect> GetRedirect(string key);

        Task AddRedirect(Redirect redirect);
        
        Task<bool> DeleteRedirect(string key);

        Task<Redirect[]> GetRedirects();
       
    }
}
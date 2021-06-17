using NiceRedirectServer.Db.Models;

namespace NiceRedirectServer.Storage
{
    public interface IStorage
    {
        bool HasRedirect(string key);
        Redirect GetRedirect(string key);

        void AddRedirect(Redirect redirect);

        Redirect[] GetRedirects();
    }
}
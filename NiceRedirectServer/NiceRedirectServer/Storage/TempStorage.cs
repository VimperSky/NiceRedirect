using System.Collections.Concurrent;
using System.Linq;
using NiceRedirectServer.Models;

namespace NiceRedirectServer.Storage
{
    public class TempStorage: IStorage
    {
        private readonly ConcurrentDictionary<string, Redirect> _redirects = new();

        public bool HasRedirect(string key)
        {
            return _redirects.ContainsKey(key);
        }

        public Redirect GetRedirect(string key)
        {
            return HasRedirect(key) ? _redirects[key] : null;
        }

        public void AddRedirect(Redirect redirect)
        {
            _redirects[redirect.Key] = redirect;
        }

        public Redirect[] GetRedirects()
        {
            return _redirects.Values.ToArray();
        }
    }
}
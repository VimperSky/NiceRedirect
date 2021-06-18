// using System.Collections.Concurrent;
// using System.Linq;
// using System.Threading.Tasks;
// using NiceRedirectServer.Models;
//
// namespace NiceRedirectServer.Storage
// {
//     public class TempStorage: IStorage
//     {
//         private readonly ConcurrentDictionary<string, Redirect> _redirects = new();
//
//         public Task<bool> HasRedirect(string key)
//         {
//             return Task.FromResult(_redirects.ContainsKey(key));
//         }
//
//         public Task<Redirect> GetRedirect(string key)
//         {
//             return Task.FromResult(HasRedirect(key).Result ? _redirects[key] : null);
//         }
//
//         public Task AddRedirect(Redirect redirect)
//         {
//             _redirects[redirect.Key] = redirect;
//             return Task.CompletedTask;
//         }
//
//         public Task<Redirect[]> GetRedirects()
//         {
//             return Task.FromResult(_redirects.Values.ToArray());
//         }
//     }
// }
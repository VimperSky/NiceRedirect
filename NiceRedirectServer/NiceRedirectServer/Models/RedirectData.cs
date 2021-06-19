using Microsoft.EntityFrameworkCore;

namespace NiceRedirectServer.Models
{
    [Owned]
    public class RedirectData
    {
        public string Target { get; init; }
        
        public RedirectType Type { get; init; }
        
        public string Password { get; init; }
    }
}
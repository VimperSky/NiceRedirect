using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NiceRedirectServer.Models;
using NiceRedirectServer.Storage;

namespace NiceRedirectServer.Logic
{
    public class RedirectCreator
    {
        private readonly IStorage _storage;
        private readonly ILogger<RedirectCreator> _logger;

        public RedirectCreator(IStorage storage, ILogger<RedirectCreator> logger)
        {
            _storage = storage;
            _logger = logger;
        }
        
        private readonly Random _random = new();

        private const string Alphabet = "abcdefghijklmnopqrstuvwyxz0123456789";

        private string GenerateString(int size)
        {
            var chars = new char[size];
            for (var i=0; i < size; i++)
            {
                chars[i] = Alphabet[_random.Next(Alphabet.Length)];
            }
            return new string(chars);
        }
        
        public async Task<Redirect> Create(RedirectData redirectData)
        {
            string shortLink;

            do
            {
                shortLink = GenerateString(8);
            }
            while (await _storage.GetRedirect(shortLink) != null); // избегаем конфликтов.
            
            var redirectFull = new Redirect {Key = shortLink, Data = redirectData};
            await _storage.AddRedirect(redirectFull);
            
            return redirectFull;
        }
    }
}
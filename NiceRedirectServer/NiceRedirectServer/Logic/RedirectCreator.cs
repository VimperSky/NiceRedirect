using System;
using NiceRedirectServer.Models;

namespace NiceRedirectServer.Logic
{
    public class RedirectCreator
    {
        private readonly Random _random = new();

        private const string Alphabet = "abcdefghijklmnopqrstuvwyxz0123456789";

        public string GenerateString(int size)
        {
            var chars = new char[size];
            for (var i=0; i < size; i++)
            {
                chars[i] = Alphabet[_random.Next(Alphabet.Length)];
            }
            return new string(chars);
        }
        
        public Redirect Create(string target)
        {
            var shortLink = GenerateString(8);
            return new Redirect {ShortLink = shortLink, Target = target};
        }
    }
}
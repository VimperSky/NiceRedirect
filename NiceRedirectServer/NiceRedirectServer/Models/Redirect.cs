using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NiceRedirectServer.Models
{
    [Index(nameof(Key), IsUnique = true)]
    public class Redirect
    {
        [Key]
        public string Key { get; init; }
        public RedirectData Data { get; init; }
    }
}
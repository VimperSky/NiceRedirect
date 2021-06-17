﻿using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NiceRedirectServer.Db.Models
{
    [Index(nameof(Key), IsUnique = true)]
    public class Redirect
    {
        [Key]
        public string Key { get; init; }
        public string Target { get; init; }
    }
}
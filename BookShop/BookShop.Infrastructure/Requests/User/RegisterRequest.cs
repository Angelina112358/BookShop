﻿using System.ComponentModel.DataAnnotations;

namespace BookShop.Infrastructure.Requests.User
{
    public class RegisterRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

    }
}

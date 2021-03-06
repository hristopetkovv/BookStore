﻿using System.ComponentModel.DataAnnotations;

namespace BookStore.Services.ViewModels.Account
{
    public class LoginRequestModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

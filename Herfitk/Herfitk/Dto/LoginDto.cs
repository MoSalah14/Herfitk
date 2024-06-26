﻿using System.ComponentModel.DataAnnotations;

namespace Herfitk.API.Dto
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string? DisplayName { get; set; }
    }
}
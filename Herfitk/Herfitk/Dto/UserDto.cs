﻿using System.ComponentModel.DataAnnotations;

namespace Herfitk.API.Dto
{
    public class UserDto
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
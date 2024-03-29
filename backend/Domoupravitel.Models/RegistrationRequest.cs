﻿using System.ComponentModel.DataAnnotations;
using Domoupravitel.Models.Enums;

namespace Domoupravitel.Models
{
    public class RegistrationRequest
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public Role? Role { get; set; } = null!;
    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace iTrendz.Api.Authentication
{
    public class RegistrationModel
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string UserType { get; set; }
        public required string Description { get; set; }
        [EmailAddress] public required string Email { get; set; }
    }
}
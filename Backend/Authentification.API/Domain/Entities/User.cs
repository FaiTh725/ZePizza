﻿using Authentification.API.Domain.Enums;

namespace Authentification.API.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; } = Role.Customer;
    }
}

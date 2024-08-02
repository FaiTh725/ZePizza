﻿using Authentification.Domain.Entities;

namespace Authentification.API.Infastructure.Interfaces
{
    public interface IJwtProvider
    {
        public string GenerateToken(User user);
    }
}

﻿using BookStore.Data.Models;

namespace BookStore.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}

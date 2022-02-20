﻿using BookStore.Services.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace BookStore.Services.Infrastructure.Auth
{
    public class UserContext : IUserContext
    {
        private ClaimsPrincipal _user;

        public int UserId => int.Parse(_user.Claims.Single(c => c.Type.Equals(JwtRegisteredClaimNames.Jti)).Value);
        public string Username => _user.Claims.Single(c => c.Type.Equals("username")).Value;
        public string Role => _user.Claims.Single(c => c.Type == ClaimTypes.Role).Value;

        public UserContext(IHttpContextAccessor contextAccessor)
        {
            this._user = contextAccessor.HttpContext?.User;
        }
    }
}

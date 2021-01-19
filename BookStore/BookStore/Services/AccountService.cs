using BookStore.Data;
using BookStore.Data.Models;
using BookStore.ViewModels.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class AccountService : IAccountService
    {
        private readonly BookStoreDbContext dbContext;
        private readonly ITokenService tokenService;

        public AccountService(BookStoreDbContext dbContext, ITokenService tokenService)
        {
            this.dbContext = dbContext;
            this.tokenService = tokenService;
        }

        public async Task<UserResponseModel> Register(RegisterRequestModel model)
        {
            await this.UserExists(model.Username);

            using var hmac = new HMACSHA512();

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Username = model.Username,
                PhoneNumber = model.TelephoneNumber,
                Address = model.Address,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(model.Password)),
                PasswordSalt = hmac.Key
            };

            user.Role = Role.User;

            this.dbContext.User.Add(user);

            await this.dbContext.SaveChangesAsync();

            return new UserResponseModel
            {
                Username = user.Username,
                Token = this.tokenService.CreateToken(user)
            };
        }

        public async Task<UserResponseModel> Login(LoginRequestModel model)
        {
            var user = await this.dbContext
               .User
               .SingleOrDefaultAsync(u => u.Username == model.Username);

            if (user == null)
            {
                throw new InvalidOperationException("Invalid username");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(model.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    throw new InvalidOperationException("Invalid password");
                }
            }

            return new UserResponseModel
            {
                Username = user.Username,
                Token = this.tokenService.CreateToken(user)
            };
        }

        private async Task<string> UserExists(string username)
        {
            var exists = await this.dbContext.User.AnyAsync(u => u.Username.ToLower() == username.ToLower());

            if (exists)
            {
                throw new InvalidOperationException("Username is taken");
            }

            return string.Empty;
        }
    }
}

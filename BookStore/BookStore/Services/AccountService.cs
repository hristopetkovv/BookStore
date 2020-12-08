using BookStore.Data;
using BookStore.Data.Models;
using BookStore.ViewModels.Account;
using Microsoft.EntityFrameworkCore;
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

        public async Task<UserResponseModel> Create(RegisterRequestModel model)
        {
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

            this.dbContext.User.Add(user);

            await this.dbContext.SaveChangesAsync();

            return new UserResponseModel
            {
                Username = user.Username,
                Token = this.tokenService.CreateToken(user)
            };
        }

        public Task Login(LoginRequestModel model)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UserExists(string username)
        {
            return await this.dbContext.User.AnyAsync(u => u.Username == username.ToLower());
        }
    }
}

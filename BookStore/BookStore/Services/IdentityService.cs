using BookStore.Data;
using BookStore.Data.Models;
using BookStore.ViewModels.Identity;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly BookStoreDbContext dbContext;

        public IdentityService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Create(RegisterRequestModel model)
        {
            byte[] hashedPass = this.CalculateSHA256(model.Password);

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Username = model.Username,
                PhoneNumber = model.TelephoneNumber,
                Password = hashedPass.ToString(),
                Address = model.Address
            };

            this.dbContext.User.Add(user);

            await this.dbContext.SaveChangesAsync();

            return user.Id;
        }

        public Task Login(LoginRequestModel model)
        {
            throw new System.NotImplementedException();
        }

        private byte[] CalculateSHA256(string pass)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] hashValue;
            UTF8Encoding objUtf8 = new UTF8Encoding();
            hashValue = sha256.ComputeHash(objUtf8.GetBytes(pass));

            return hashValue;
        }
    }
}

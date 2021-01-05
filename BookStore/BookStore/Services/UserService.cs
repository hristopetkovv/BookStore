using BookStore.Data;
using BookStore.ViewModels.Account;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class UserService : IUserService
    {
        private readonly BookStoreDbContext dbContext;

        public UserService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UserInformationResponseModel> GetUser(int userId)
        {
            return await this.dbContext.User
                .Where(u => u.Id == userId)
                .Select(u => new UserInformationResponseModel
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Address = u.Address,
                    PhoneNumber = u.PhoneNumber,
                    Username = u.Username,
                    Email = u.Email
                })
                .FirstOrDefaultAsync();
        }
    }
}

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
                    Email = u.Email,
                })
                .FirstOrDefaultAsync();
        }

        public async Task UpdateUser(UserInformationResponseModel model)
        {
            var user = await this.dbContext
                .User
                .FirstOrDefaultAsync(u => u.Id == model.Id);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Username = model.Username;
            user.Address = model.Address;
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Email;

            await this.dbContext.SaveChangesAsync();
        }
    }
}

using BookStore.Services.ViewModels.Account;
using System.Threading.Tasks;

namespace BookStore.Services.Services
{
    public interface IUserService
    {
        Task<UserInformationResponseModel> GetUser(int userId);

        Task UpdateUser(UserInformationResponseModel model);
    }
}

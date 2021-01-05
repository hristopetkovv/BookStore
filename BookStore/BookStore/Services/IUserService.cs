using BookStore.ViewModels.Account;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IUserService
    {
        Task<UserInformationResponseModel> GetUser(int userId);

        Task UpdateUser(UserInformationResponseModel model);
    }
}

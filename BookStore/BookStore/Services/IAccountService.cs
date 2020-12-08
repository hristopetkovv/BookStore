using BookStore.ViewModels.Account;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IAccountService
    {
        Task<UserResponseModel> Create(RegisterRequestModel model);

        Task Login(LoginRequestModel model);

        Task<bool> UserExists(string username);
    }
}

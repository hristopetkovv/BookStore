using BookStore.ViewModels.Account;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IAccountService
    {
        Task<UserResponseModel> Register(RegisterRequestModel model);

        Task<UserResponseModel> Login(LoginRequestModel model);
    }
}

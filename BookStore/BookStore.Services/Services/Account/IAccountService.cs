using BookStore.Services.ViewModels.Account;
using System.Threading.Tasks;

namespace BookStore.Services.Services
{
    public interface IAccountService
    {
        Task<UserResponseModel> Register(RegisterRequestModel model);

        Task<UserResponseModel> Login(LoginRequestModel model);
    }
}

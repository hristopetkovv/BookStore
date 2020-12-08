using BookStore.ViewModels.Account;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IAccountService
    {
        Task<UserResponseModel> Create(RegisterRequestModel model);

        Task<UserResponseModel> Login(LoginRequestModel model);
    }
}

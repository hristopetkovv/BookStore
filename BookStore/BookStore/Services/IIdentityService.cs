using BookStore.ViewModels.Identity;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IIdentityService
    {
        Task<int> Create(RegisterRequestModel model);

        Task Login(LoginRequestModel model);
    }
}

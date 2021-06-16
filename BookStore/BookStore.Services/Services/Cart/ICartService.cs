using BookStore.Services.ViewModels.Home;
using System.Threading.Tasks;

namespace BookStore.Services.Services
{
    public interface ICartService
    {
        Task<CartListingResponseModel> ShowCart(int userId);

        Task RemoveBook(int bookId);
    }
}

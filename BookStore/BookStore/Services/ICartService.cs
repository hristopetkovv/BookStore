using BookStore.ViewModels.Home;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface ICartService
    {
        Task<CartListingResponseModel> ShowCart(int userId);

        Task RemoveBook(int bookId);
    }
}

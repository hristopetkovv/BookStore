using BookStore.ViewModels.Home;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IUserService
    {
        Task<CartListingResponseModel> ShowCart(int userId);

        Task RemoveBook(int bookId);

        Task CreateOrder(int userId, decimal totalPrice);
    }
}

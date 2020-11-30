using BookStore.ViewModels.Home;
using System.Collections.Generic;

namespace BookStore.Services
{
    public interface IUserService
    {
        IEnumerable<CartResponseModel> ShowCart(int userId);
    }
}

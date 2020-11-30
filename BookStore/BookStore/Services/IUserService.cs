using BookStore.ViewModels.Home;
using System.Collections.Generic;

namespace BookStore.Services
{
    public interface IUserService
    {
        CartListingResponseModel ShowCart(int userId);
    }
}

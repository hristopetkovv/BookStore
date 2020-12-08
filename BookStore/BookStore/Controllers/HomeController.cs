using System.Threading.Tasks;
using BookStore.Services;
using BookStore.ViewModels.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Authorize]
    public class HomeController : BaseApiController
    {
        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<CartListingResponseModel> MyCart()
        {
            return await this.userService.ShowCart(1);
        }

        [HttpDelete]
        public async Task RemoveBook([FromQuery] int bookId)
        {
            await this.userService.RemoveBook(bookId);
        }
    }
}

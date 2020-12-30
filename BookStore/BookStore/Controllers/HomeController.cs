using System.Security.Claims;
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
            var claimsIdentity = User.Identity as ClaimsIdentity;

            var userId = int.Parse(claimsIdentity.FindFirst("userId").Value);

            return await this.userService.ShowCart(userId);
        }

        [HttpDelete]
        [Route("{bookId:int}")]
        public async Task RemoveBook([FromRoute] int bookId)
        {
            await this.userService.RemoveBook(bookId);
        }
    }
}

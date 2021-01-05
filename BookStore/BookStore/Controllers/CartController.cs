using System.Security.Claims;
using System.Threading.Tasks;
using BookStore.Services;
using BookStore.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class CartController : BaseApiController
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpGet]
        public async Task<CartListingResponseModel> MyCart()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;

            var userId = int.Parse(claimsIdentity.FindFirst("userId").Value);

            return await this.cartService.ShowCart(userId);
        }

        [HttpDelete]
        [Route("{bookId:int}")]
        public async Task<CartListingResponseModel> RemoveBook([FromRoute] int bookId)
        {
            await this.cartService.RemoveBook(bookId);

            var claimsIdentity = User.Identity as ClaimsIdentity;

            var userId = int.Parse(claimsIdentity.FindFirst("userId").Value);

            return await this.cartService.ShowCart(userId);
        }
    }
}

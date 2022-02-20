using System.Threading.Tasks;
using BookStore.Services.Common.Interfaces;
using BookStore.Services.Services;
using BookStore.Services.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers.Controllers
{
	public class CartController : BaseApiController
	{
		private readonly ICartService cartService;
		private readonly IUserContext userContext;

		public CartController(ICartService cartService, IUserContext userContext)
		{
			this.cartService = cartService;
			this.userContext = userContext;
		}

		[HttpGet]
		public async Task<CartListingResponseModel> MyCart()
		{
			return await this.cartService.ShowCart(this.userContext.UserId);
		}

		[HttpDelete]
		[Route("{bookId:int}")]
		public async Task RemoveBook([FromRoute] int bookId)
		{
			await this.cartService.RemoveBook(bookId);
		}
	}
}

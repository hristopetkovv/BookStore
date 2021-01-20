﻿using System.Threading.Tasks;
using BookStore.Services;
using BookStore.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class CartController : BaseApiController
    {
        private readonly ICartService cartService;
        private readonly UserContext userContext;

        public CartController(ICartService cartService, UserContext userContext)
        {
            this.cartService = cartService;
            this.userContext = userContext;
        }

        [HttpGet]
        public async Task<CartListingResponseModel> MyCart()
        {
            return await this.cartService.ShowCart(this.userContext.UserId.Value);
        }

        [HttpDelete]
        [Route("{bookId:int}")]
        public async Task RemoveBook([FromRoute] int bookId)
        {
            await this.cartService.RemoveBook(bookId);
        }
    }
}

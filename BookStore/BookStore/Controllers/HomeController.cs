﻿using System.Threading.Tasks;
using BookStore.Services;
using BookStore.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<CartListingResponseModel> MyCart()
        {
            return await this.userService.ShowCart(2);
        }

        [HttpDelete]
        public async Task RemoveBook([FromQuery] int bookId)
        {
            await this.userService.RemoveBook(bookId);
        }

        [HttpPost]
        public async Task CompleteOrder([FromQuery] decimal totalPrice)
        {
            await this.userService.CreateOrder(2, totalPrice);
        }
    }
}
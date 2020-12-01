using System.Collections.Generic;
using System.Threading.Tasks;
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
        private readonly IOrderService orderService;

        public HomeController(IUserService userService, IOrderService orderService)
        {
            this.userService = userService;
            this.orderService = orderService;
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
            await this.orderService.CreateOrder(2, totalPrice);
        }

        [HttpGet]
        [Route("/orders")]
        public async Task<IEnumerable<OrderResponseModel>> Orders()
        {
            return await this.orderService.GetOrders(2);
        }
    }
}

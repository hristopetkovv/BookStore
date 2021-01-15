using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BookStore.Services;
using BookStore.ViewModels.Orders;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class OrderController : BaseApiController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        public async Task CompleteOrder([FromBody] decimal totalPrice)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;

            var userId = int.Parse(claimsIdentity.FindFirst("userId").Value);

            await this.orderService.CreateOrder(userId, totalPrice);
        }

        [HttpGet]
        public async Task<IEnumerable<OrderResponseModel>> Orders()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;

            var userId = int.Parse(claimsIdentity.FindFirst("userId").Value);

            return await this.orderService.GetOrders(userId);
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Services;
using BookStore.ViewModels.Orders;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpPost]
        public async Task CompleteOrder([FromQuery] decimal totalPrice)
        {
            await this.orderService.CreateOrder(1, totalPrice);
        }

        [Authorize]
        [HttpGet("orders")]
        public async Task<IEnumerable<OrderResponseModel>> Orders()
        {
            return await this.orderService.GetOrders(1);
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Services;
using BookStore.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
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

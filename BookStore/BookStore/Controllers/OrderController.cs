using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Services;
using BookStore.ViewModels.Orders;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class OrderController : BaseApiController
    {
        private readonly IOrderService orderService;
        private readonly UserContext userContext;

        public OrderController(IOrderService orderService, UserContext userContext)
        {
            this.orderService = orderService;
            this.userContext = userContext;
        }

        [HttpPost]
        public async Task CompleteOrder([FromBody] decimal totalPrice)
        {
            await this.orderService.CreateOrder(this.userContext.UserId.Value, totalPrice);
        }

        [HttpGet]
        public async Task<IEnumerable<OrderResponseModel>> Orders()
        {
            return await this.orderService.GetOrders(this.userContext.UserId.Value);
        }
    }
}

﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Services.Common.Interfaces;
using BookStore.Services.Services;
using BookStore.Services.ViewModels.Orders;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers.Controllers
{
    public class OrderController : BaseApiController
    {
        private readonly IOrderService orderService;
        private readonly IUserContext userContext;

        public OrderController(IOrderService orderService, IUserContext userContext)
        {
            this.orderService = orderService;
            this.userContext = userContext;
        }

        [HttpPost]
        public async Task CompleteOrder([FromBody] decimal totalPrice)
        {
            await this.orderService.CreateOrder(this.userContext.UserId, totalPrice);
        }

        [HttpGet]
        public async Task<IEnumerable<OrderResponseModel>> Orders()
        {
            return await this.orderService.GetOrders(this.userContext.UserId);
        }
    }
}

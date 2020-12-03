﻿using BookStore.ViewModels.Books;
using BookStore.ViewModels.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IAdminService
    {
        Task AddBook(BookRequestModel model);

        Task<IEnumerable<OrderResponseModel>> GetOrders();

        Task UpdateOrder(OrderUpdateRequestModel model);
    }
}
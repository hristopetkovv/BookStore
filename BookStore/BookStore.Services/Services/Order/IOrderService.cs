using BookStore.Services.ViewModels.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services.Services
{
    public interface IOrderService
    {
        Task CreateOrder(int userId, decimal totalPrice);

        Task<IEnumerable<OrderResponseModel>> GetOrders(int userId);
    }
}

using BookStore.Data.Data.Models.Enums;

namespace BookStore.Services.ViewModels.Orders
{
    public class OrderUpdateRequestModel
    {
        public int OrderId { get; set; }

        public Status Status { get; set; }
    }
}

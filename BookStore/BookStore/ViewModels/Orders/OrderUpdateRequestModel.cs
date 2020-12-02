using BookStore.Data.Models.Enums;

namespace BookStore.ViewModels.Orders
{
    public class OrderUpdateRequestModel
    {
        public int OrderId { get; set; }

        public Status Status { get; set; }
    }
}

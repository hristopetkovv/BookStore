using System.Collections.Generic;

namespace BookStore.ViewModels.Home
{
    public class CartListingResponseModel
    {
        public decimal TotalPrice { get; set; }

        public IEnumerable<CartViewModel> Books { get; set; }
    }
}

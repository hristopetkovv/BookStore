using System.Collections.Generic;

namespace BookStore.ViewModels.Home
{
    public class CartViewModel
    {
        public int BookId { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal PriceForEach { get; set; }

        public decimal Discount { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public IEnumerable<string> AuthorName { get; set; }

        public int Pieces { get; set; }
    }
}

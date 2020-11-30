using BookStore.ViewModels.Books;
using System.Collections.Generic;

namespace BookStore.ViewModels.Home
{
    public class CartResponseModel
    {
        public int BookId { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public IEnumerable<string> AuthorName { get; set; }

        public int Pieces { get; set; }
    }
}

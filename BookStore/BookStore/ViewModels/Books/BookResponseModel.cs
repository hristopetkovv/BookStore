using System.Collections.Generic;

namespace BookStore.ViewModels.Books
{
    public class BookResponseModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<string> AuthorName { get; set; }

    }
}

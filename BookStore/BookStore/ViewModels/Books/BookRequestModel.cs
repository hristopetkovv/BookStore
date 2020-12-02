using BookStore.Data.Models;
using System;

namespace BookStore.ViewModels.Books
{
    public class BookRequestModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public bool IsAvailable { get; set; }

        public string PublishHouse { get; set; }

        public string ImageUrl { get; set; }

        public string AuthorFirstName { get; set; }

        public string AuthorLastName { get; set; }

        public string Genre { get; set; }

        public DateTime PublishedOn { get; set; }
    }
}

using BookStore.Services.ViewModels.Comments;
using System;
using System.Collections.Generic;

namespace BookStore.Services.ViewModels.Books
{
    public class BookDetailalsResponseModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        public int Quantity { get; set; }

        public string PublishHouse { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<string> AuthorName { get; set; }

        public IEnumerable<CommentResponseModel> Comments { get; set; }

        public string Genre { get; set; }

        public DateTime PublishedOn { get; set; }

        public int DownVotes { get; set; }

        public int UpVotes { get; set; }

        public List<string> Keywords { get; set; } = new List<string>();
    }
}

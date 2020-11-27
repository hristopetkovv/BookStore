using System;

namespace BookStore.ViewModels.Books
{
    public class BookCommentResponseModel
    {
        public string Text { get; set; }

        public string Username { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}

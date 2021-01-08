using System;

namespace BookStore.ViewModels.Comments
{
    public class CommentResponseModel
    {
        public string Comment { get; set; }

        public string Username { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}

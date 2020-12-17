using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels.Books
{
    public class BookCommentResponseModel
    {
        
        public string Comment { get; set; }

        public string Username { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}

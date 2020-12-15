using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels.Books
{
    public class BookCommentResponseModel
    {
        [Required]
        [MaxLength(200)]
        public string Comment { get; set; }

        [Required]
        public string Username { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}

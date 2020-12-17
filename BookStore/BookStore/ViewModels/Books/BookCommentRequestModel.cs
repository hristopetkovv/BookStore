using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels.Books
{
    public class BookCommentRequestModel
    {
        [Required]
        [MaxLength(200)]
        public string Comment { get; set; }

        [Required]
        public string Username { get; set; }
    }
}

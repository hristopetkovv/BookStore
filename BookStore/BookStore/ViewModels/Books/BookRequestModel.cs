using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels.Books
{
    public class BookRequestModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [Range(0.0, 1000000000000)]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        [MaxLength(100)]
        public string PublishHouse { get; set; }

        public string ImageUrl { get; set; }

        public string AuthorFirstName { get; set; }

        public string AuthorLastName { get; set; }

        public string Genre { get; set; }

        public DateTime PublishedOn { get; set; }
    }
}

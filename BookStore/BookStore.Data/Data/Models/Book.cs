using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Data.Data.Models
{
    public class Book
    {
        public Book()
        {
            this.Authors = new HashSet<BookAuthor>();
            this.Comments = new HashSet<Comment>();
            this.Users = new HashSet<UserBook>();
            this.Votes = new HashSet<Vote>();
            this.BookKeyWords = new HashSet<BookKeyWords>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [Range(0.0, 1000000000000)]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public bool IsAvailable { get; set; }

        public string PublishHouse { get; set; }

        public string ImageUrl { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public DateTime PublishedOn { get; set; }

        public virtual ICollection<BookKeyWords> BookKeyWords { get; set; }

        public virtual ICollection<BookAuthor> Authors { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<UserBook> Users { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}

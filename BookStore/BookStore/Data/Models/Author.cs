using BookStore.Data.Common;
using System.Collections.Generic;

namespace BookStore.Data.Models
{
    public class Author : BaseModel
    {
        public Author()
        {
            this.Books = new HashSet<BookAuthor>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Fullname { get; set; }

        public ICollection<BookAuthor> Books { get; set; }
    }
}

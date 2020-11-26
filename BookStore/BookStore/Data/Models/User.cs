using BookStore.Data.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Data.Models
{
    public class User : BaseDeletableModel
    {
        public User()
        {
            this.Books = new HashSet<UserBook>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Username { get; set; }

        public string TelephoneNumber { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public ICollection<UserBook> Books { get; set; }
    }
}

using BookStore.Data.Common;
using BookStore.Data.Models.Enums;
using System;

namespace BookStore.Data.Models
{
    public class UserBook : BaseDeletableModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }

        public int Pieces { get; set; }

        public DateTime BoughtOn { get; set; }

        public Status Status { get; set; }
    }
}

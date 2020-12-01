using BookStore.Data.Models.Enums;
using System;

namespace BookStore.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime BoughtOn { get; set; }

        public Status Status { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public decimal TotalPrice { get; set; }

        public int? BookId { get; set; }

        public Book Book { get; set; }
    }
}

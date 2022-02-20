using BookStore.Data.Data.Models.Enums;
using System;

namespace BookStore.Data.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime BoughtOn { get; set; }

        public Status Status { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public decimal TotalPrice { get; set; }
    }
}

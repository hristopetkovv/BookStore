using BookStore.Data.Data.Common;
using BookStore.Data.Data.Models.Enums;
using System;

namespace BookStore.Data.Data.Models
{
    public class Order : BaseModel
    {
        public int Id { get; set; }

        public DateTime BoughtOn { get; set; }

        public Status Status { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public decimal TotalPrice { get; set; }
    }
}

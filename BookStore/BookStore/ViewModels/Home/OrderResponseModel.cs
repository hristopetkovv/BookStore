using BookStore.Data.Models.Enums;
using System;

namespace BookStore.ViewModels.Home
{
    public class OrderResponseModel
    {
        public int Id { get; set; }

        public Status Status { get; set; }

        public DateTime BoughtOn { get; set; }

        public decimal TotalPrice { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string TelephoneNumber { get; set; }

        public string Address { get; set; }
    }
}

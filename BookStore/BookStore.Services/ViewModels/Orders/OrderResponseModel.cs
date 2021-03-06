﻿using System;

namespace BookStore.Services.ViewModels.Orders
{
    public class OrderResponseModel
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public DateTime BoughtOn { get; set; }

        public decimal TotalPrice { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string TelephoneNumber { get; set; }

        public string Address { get; set; }
    }
}

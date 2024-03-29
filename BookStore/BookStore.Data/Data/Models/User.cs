﻿using System.Collections.Generic;

namespace BookStore.Data.Data.Models
{
    public class User
    {
        public User()
        {
            this.Books = new HashSet<UserBook>();
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public byte[] PasswordSalt { get; set; }

        public byte[] PasswordHash { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Role { get; set; }

        public string Username { get; set; }

        public ICollection<UserBook> Books { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}

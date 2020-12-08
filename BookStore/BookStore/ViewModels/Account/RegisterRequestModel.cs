using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels.Account
{
    public class RegisterRequestModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string TelephoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Address { get; set; }

    }
}

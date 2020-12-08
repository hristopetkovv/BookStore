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
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [Phone]
        public string TelephoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Address { get; set; }

    }
}

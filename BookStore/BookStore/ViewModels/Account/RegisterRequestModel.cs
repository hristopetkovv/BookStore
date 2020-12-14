using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels.Account
{
    public class RegisterRequestModel
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [Phone]
        public string TelephoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(150)]
        public string Address { get; set; }

    }
}

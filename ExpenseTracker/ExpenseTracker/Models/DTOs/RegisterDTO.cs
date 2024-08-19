using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models.DTOs
{
    public class RegisterDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid Email Address")]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? ConfirmPassword { get; set; }

    }
}

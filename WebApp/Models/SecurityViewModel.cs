using System.ComponentModel.DataAnnotations;
using WebApp.Helpers;

namespace WebApp.Models
{
    public class SecurityViewModel
    {
        [Display(Name = "Current Password", Prompt = "Enter your password")]
        [Required(ErrorMessage = "You must enter a password")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_])(?!.*\s).{8,}$", ErrorMessage = "A valid password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "New password", Prompt = "Enter your new password")]
        [Required(ErrorMessage = "You must enter a password")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_])(?!.*\s).{8,}$", ErrorMessage = "A valid password is required")]
        [DataType(DataType.Password)]
        public string newPassword { get; set; } = null!;

        [Display(Name = "Confirm new assword", Prompt = "Confirm your password")]
        [Required(ErrorMessage = "Password must be confirmed")]
        [Compare(nameof(Password), ErrorMessage = "Passwords don't match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

        [Display(Name = "Yes, I want to delete my account.")]
        [CheckboxRequired(ErrorMessage = "You must accept the terms and conditions")]
        public bool deleteAccount { get; set; } 
    }
}

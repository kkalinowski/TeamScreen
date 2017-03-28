using System.ComponentModel.DataAnnotations;

namespace TeamScreen.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

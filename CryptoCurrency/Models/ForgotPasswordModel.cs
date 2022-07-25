using System.ComponentModel.DataAnnotations;

namespace CryptoCurrency.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

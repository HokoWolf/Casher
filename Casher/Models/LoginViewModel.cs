using System.ComponentModel.DataAnnotations;

namespace Casher.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "CardNumber")]
        public string? CardNumber { get; set; }

        [Required]
        [Display(Name = "PinCode")]
        public string? PinCode { get; set; }
    }
}

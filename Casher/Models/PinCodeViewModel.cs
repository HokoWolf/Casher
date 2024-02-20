using System.ComponentModel.DataAnnotations;

namespace Casher.Models
{
    public class PinCodeViewModel
    {
        [Required]
        [Display(Name = "PinCode")]
        public string? PinCode { get; set; }
    }
}

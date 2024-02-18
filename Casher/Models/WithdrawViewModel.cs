using System.ComponentModel.DataAnnotations;

namespace Casher.Models
{
    public class WithdrawViewModel
    {
        [Required]
        [Display(Name = "MoneyAmount")]
        public double? MoneyAmount { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Casher.Areas.User.Models
{
    public class WithdrawViewModel
    {
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; } = null!;

        [Display(Name = "Date")]
        public string Date { get; set; } = null!;

        [Display(Name = "Date")]
        public string Time { get; set; } = null!;

        [Required]
        [Display(Name = "MoneyAmount")]
        public double? MoneyAmount { get; set; }

        [Display(Name = "Balance")]
        public double Balance { get; set; }
    }
}

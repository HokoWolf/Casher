using System.ComponentModel.DataAnnotations;

namespace Casher.Areas.User.Models
{
    public class BalanceViewModel
    {
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; } = null!;

        [Display(Name = "Date")]
        public string Date { get; set; } = null!;

        [Display(Name = "Balance")]
        public double Balance { get; set; }
    }
}

using Casher.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Casher.Models.Entities
{
	[Table("bank_accounts", Schema = "dbo")]
	[Index(nameof(CardNumber), Name = "IX_card_number", IsUnique = true)]
	public partial class BankAccount : BaseEntity
	{
		[Column("card_number")]
		[Required, StringLength(maximumLength: 16, MinimumLength = 16)]
		public string CardNumber { get; set; } = null!;

		[Column("pin_code")]
		[Required, StringLength(maximumLength: 4, MinimumLength = 4)]
		public string PinCode { get; set; } = null!;

		[Column("account_balance")]
		[DefaultValue(0)]
		public double AccountBalance { get; set; }

		[Column("is_blocked")]
		[DefaultValue(false)]
		public bool IsBlocked { get; set; }

		[JsonIgnore]
		[InverseProperty(nameof(Operation.BankAccountNavigation))]
		public IEnumerable<Operation> Operations { get; set; } = new List<Operation>();

		[JsonIgnore]
		[InverseProperty(nameof(PinCodeAttempt.BankAccountNavigation))]
		public IEnumerable<PinCodeAttempt> PinCodeAttempts { get; set; } = new List<PinCodeAttempt>();

		[JsonIgnore]
		[NotMapped]
		public string ViewCardNumber
		{
			get
			{
                StringBuilder viewCardNumber = new(CardNumber);

                for (int i = viewCardNumber.Length - 4; i > 0; i -= 4)
                {
                    viewCardNumber.Insert(i, '-');
                }

                return viewCardNumber.ToString();
            }
		}
	}
}

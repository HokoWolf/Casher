using Casher.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Casher.Models.Entities
{
	[Table("pin_code_attempts", Schema = "dbo")]
	[Index(nameof(BankAccountId), Name = "IX_pin_code_attempts_bank_account_id")]
	public partial class PinCodeAttempt : BaseEntity
	{
		[Column("bank_account_id")]
		public int BankAccountId { get; set; }

		[Column("attempt_date_time")]
		[Required]
		public DateTime AttemptDateTime { get; set; }

		[Column("is_successful")]
		[Required]
		public bool IsSuccessful { get; set;}

		[ForeignKey(nameof(BankAccountId))]
		[InverseProperty(nameof(BankAccount.PinCodeAttempts))]
		public BankAccount? BankAccountNavigation { get; set; }
	}
}

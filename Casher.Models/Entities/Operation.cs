using Casher.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Casher.Models.Entities
{
	[Table("operations", Schema = "dbo")]
	[Index(nameof(BankAccountId), Name = "IX_operations_bank_account_id")]
	[Index(nameof(OperationTypeId), Name = "IX_operations_operation_type_id")]
	public partial class Operation : BaseEntity
	{
		[Column("bank_account_id")]
		public int BankAccountId { get; set; }

		[Column("operation_type_id")]
		public int OperationTypeId { get; set; }

		[Column("operation_date_time")]
		[Required]
		public DateTime OperationDateTime { get; set; }

		[Column("money_amount")]
		public double? MoneyAmount { get; set; }

		[ForeignKey(nameof(BankAccountId))]
		[InverseProperty(nameof(BankAccount.Operations))]
		public BankAccount? BankAccountNavigation { get; set; }

		[ForeignKey(nameof(OperationTypeId))]
		[InverseProperty(nameof(OperationType.Operations))]
		public OperationType? OperationTypeNavigation { get; set; }
	}
}

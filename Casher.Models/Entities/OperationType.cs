using Casher.Models.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Casher.Models.Entities
{
	[Table("operation_types", Schema = "dbo")]
	public partial class OperationType : BaseEntity
	{
		[Column("name")]
		[Required]
		public string Name { get; set; } = null!;

		[JsonIgnore]
		[InverseProperty(nameof(Operation.OperationTypeNavigation))]
		public IEnumerable<Operation> Operations { get; set; } = new List<Operation>();
	}
}

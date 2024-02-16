using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Casher.Models.Entities.Base
{
	public class BaseEntity
	{
		[Column("id")]
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Column("time_stamp")]
		[Timestamp]
		public byte[]? TimeStamp { get; set; }
	}
}

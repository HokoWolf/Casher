using Casher.Dal.EfStructures;
using Casher.Dal.Repos.Base;
using Casher.Dal.Repos.Interfaces;
using Casher.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Casher.Dal.Repos
{
	public class PinCodeAttemptRepo : BaseRepo<PinCodeAttempt>, IPinCodeAttemptRepo
	{
		public PinCodeAttemptRepo(AppDbContext context) : base(context) { }

		internal PinCodeAttemptRepo(DbContextOptions<AppDbContext> options) : base(options) { }
	}
}

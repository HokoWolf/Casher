using Casher.Dal.EfStructures;
using Casher.Dal.Repos.Base;
using Casher.Dal.Repos.Interfaces;
using Casher.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Casher.Dal.Repos
{
	public class OperationRepo : BaseRepo<Operation>, IOperationRepo
	{
		public OperationRepo(AppDbContext context) : base(context) { }

		internal OperationRepo(DbContextOptions<AppDbContext> options) : base(options) { }
	}
}

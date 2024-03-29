﻿using Casher.Dal.EfStructures;
using Casher.Dal.Repos.Base;
using Casher.Dal.Repos.Interfaces;
using Casher.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Casher.Dal.Repos
{
	public class OperationTypeRepo : BaseRepo<OperationType>, IOperationTypeRepo
	{
		public OperationTypeRepo(AppDbContext context) : base(context) { }

		internal OperationTypeRepo(DbContextOptions<AppDbContext> options) : base(options) { }
	}
}

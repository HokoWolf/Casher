using Casher.Dal.EfStructures;
using Casher.Dal.Repos.Base;
using Casher.Dal.Repos.Interfaces;
using Casher.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Casher.Dal.Repos
{
	public class BankAccountRepo : BaseRepo<BankAccount>, IBankAccountRepo
	{
		public BankAccountRepo(AppDbContext context) : base(context) { }

		internal BankAccountRepo(DbContextOptions<AppDbContext> options) : base(options) { }

        public BankAccount? FindByCardNumber(string? cardNumber)
			=> Table.FirstOrDefault(acc => acc.CardNumber == cardNumber);

        public Task<BankAccount?> FindByCardNumberAsync(string? cardNumber)
			=> Table.FirstOrDefaultAsync(acc => acc.CardNumber == cardNumber);
    }
}

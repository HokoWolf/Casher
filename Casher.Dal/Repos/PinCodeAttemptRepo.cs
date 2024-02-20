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

        public int GetUnsuccessfulAttemptsCount(BankAccount bankAccount)
        {
            DateTime? lastSuccessDateTime = Table.OrderByDescending(attempt => attempt.AttemptDateTime)
                .FirstOrDefault(attempt => attempt.IsSuccessful && attempt.BankAccountId == bankAccount.Id)?.AttemptDateTime;

            return Table.Count(attempt => attempt.AttemptDateTime > lastSuccessDateTime && 
                attempt.BankAccountId == bankAccount.Id);
        }

        public async Task<int> GetUnsuccessfulAttemptsCountAsync(BankAccount bankAccount)
        {
            PinCodeAttempt? lastSuccessfulAttempt = await Table
                .OrderByDescending(attempt => attempt.AttemptDateTime)
                .FirstOrDefaultAsync(attempt => attempt.IsSuccessful && attempt.BankAccountId == bankAccount.Id);

            DateTime? lastSuccessDateTime = lastSuccessfulAttempt?.AttemptDateTime;

            return await Table.CountAsync(attempt => attempt.AttemptDateTime > lastSuccessDateTime && 
                attempt.BankAccountId == bankAccount.Id);
        }
    }
}

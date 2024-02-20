using Casher.Dal.Repos.Base;
using Casher.Models.Entities;

namespace Casher.Dal.Repos.Interfaces
{
	public interface IBankAccountRepo : IRepo<BankAccount>
	{
		BankAccount? FindByCardNumber(string? cardNumber);

		Task<BankAccount?> FindByCardNumberAsync(string? cardNumber);
	}
}

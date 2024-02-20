using Casher.Dal.Repos.Base;
using Casher.Models.Entities;

namespace Casher.Dal.Repos.Interfaces
{
	public interface IPinCodeAttemptRepo : IRepo<PinCodeAttempt>
	{
        public int GetUnsuccessfulAttemptsCount(BankAccount bankAccount);

        public Task<int> GetUnsuccessfulAttemptsCountAsync(BankAccount bankAccount);
    }
}

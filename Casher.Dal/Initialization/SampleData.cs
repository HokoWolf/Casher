using Casher.Models.Entities;

namespace Casher.Dal.Initialization
{
	public static class SampleData
	{
		public static List<BankAccount> BankAccounts =>
		[
			new BankAccount()
			{
				Id = 1,
				CardNumber = "1111111111111111",
				PinCode = "1111",
				AccountBalance = 250.0,
				IsBlocked = false,
			},
			new BankAccount()
			{
				Id = 2,
				CardNumber = "2222222222222222",
				PinCode = "2222",
				AccountBalance = 0.0,
				IsBlocked = false,
			},
			new BankAccount()
			{
				Id = 3,
				CardNumber = "3333333333333333",
				PinCode = "3333",
				AccountBalance = 1000.0,
				IsBlocked = true,
			}
		];

		public static List<OperationType> OperationTypes =>
		[
			new OperationType()
			{
				Id = 1,
				Name = "Balance"
			},
			new OperationType()
			{
				Id = 2,
				Name = "Withdraw Cash"
			}
		];

		public static List<Operation> Operations =>
		[
			new Operation()
			{
				Id = 1,
				BankAccountId = 1,
				OperationTypeId = 1,
				OperationDateTime = new DateTime(2024, 1, 30, 12, 30, 27, DateTimeKind.Utc)
			},
			new Operation()
			{
				Id = 2,
				BankAccountId = 2,
				OperationTypeId = 1,
				OperationDateTime = new DateTime(2024, 2, 5, 16, 15, 43, DateTimeKind.Utc)
			},
			new Operation()
			{
				Id = 3,
				BankAccountId = 2,
				OperationTypeId = 2,
				OperationDateTime = new DateTime(2024, 2, 5, 16, 17, 58, DateTimeKind.Utc),
				MoneyAmount = 800.0
			},
			new Operation()
			{
				Id = 4,
				BankAccountId = 3,
				OperationTypeId = 2,
				OperationDateTime = new DateTime(2024, 1, 16, 4, 45, 31, DateTimeKind.Utc),
				MoneyAmount = 2000.0
			},
			new Operation()
			{
				Id = 5,
				BankAccountId = 3,
				OperationTypeId = 1,
				OperationDateTime = new DateTime(2024, 1, 16, 4, 49, 3, DateTimeKind.Utc),
			},
		];

		public static List<PinCodeAttempt> PinCodeAttempts =>
		[
			new PinCodeAttempt()
			{
				Id = 1,
				BankAccountId = 1,
				AttemptDateTime = new DateTime(2024, 1, 30, 12, 29, 9, DateTimeKind.Utc),
				IsSuccessful = true
			},
			new PinCodeAttempt()
			{
				Id = 2,
				BankAccountId = 2,
				AttemptDateTime = new DateTime(2024, 2, 5, 16, 13, 52, DateTimeKind.Utc),
				IsSuccessful = false
			},
			new PinCodeAttempt()
			{
				Id = 3,
				BankAccountId = 2,
				AttemptDateTime = new DateTime(2024, 2, 5, 16, 14, 59, DateTimeKind.Utc),
				IsSuccessful = true
			},
			new PinCodeAttempt()
			{
				Id = 4,
				BankAccountId = 3,
				AttemptDateTime = new DateTime(2024, 1, 16, 4, 43, 19, DateTimeKind.Utc),
				IsSuccessful = true
			},
			new PinCodeAttempt()
			{
				Id = 5,
				BankAccountId = 3,
				AttemptDateTime = new DateTime(2024, 2, 14, 18, 19, 23, DateTimeKind.Utc),
				IsSuccessful = false
			},
			new PinCodeAttempt()
			{
				Id = 6,
				BankAccountId = 3,
				AttemptDateTime = new DateTime(2024, 2, 14, 18, 20, 49, DateTimeKind.Utc),
				IsSuccessful = false
			},
			new PinCodeAttempt()
			{
				Id = 7,
				BankAccountId = 3,
				AttemptDateTime = new DateTime(2024, 2, 14, 18, 21, 13, DateTimeKind.Utc),
				IsSuccessful = false
			},
			new PinCodeAttempt()
			{
				Id = 8,
				BankAccountId = 3,
				AttemptDateTime = new DateTime(2024, 2, 14, 18, 22, 56, DateTimeKind.Utc),
				IsSuccessful = false
			},
		];
	}
}

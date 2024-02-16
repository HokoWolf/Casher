using Casher.Dal.Initialization;
using Casher.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Casher.Dal.EfStructures
{
	public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
	{
		public DbSet<BankAccount> BankAccounts { get; set; }

		public DbSet<OperationType> OperationTypes { get; set; }

		public DbSet<Operation> Operations { get; set; }

		public DbSet<PinCodeAttempt> PinCodeAttempts { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<BankAccount>(entity =>
			{
				entity.HasData(SampleData.BankAccounts);
			});

			modelBuilder.Entity<OperationType>(entity =>
			{
				entity.HasData(SampleData.OperationTypes);
			});

			modelBuilder.Entity<Operation>(entity =>
			{
				entity.HasOne(op => op.BankAccountNavigation)
					.WithMany(acc => acc.Operations)
					.HasForeignKey(op => op.BankAccountId)
					.OnDelete(DeleteBehavior.NoAction)
					.HasConstraintName("FK_operations_bank_accounts");

				entity.HasOne(op => op.OperationTypeNavigation)
					.WithMany(type => type.Operations)
					.HasForeignKey(op => op.OperationTypeId)
					.OnDelete(DeleteBehavior.NoAction)
					.HasConstraintName("FK_operations_operation_types");

				entity.HasData(SampleData.Operations);
			});

			modelBuilder.Entity<PinCodeAttempt>(entity =>
			{
				entity.HasOne(pin => pin.BankAccountNavigation)
					.WithMany(acc => acc.PinCodeAttempts)
					.HasForeignKey(pin => pin.BankAccountId)
					.OnDelete(DeleteBehavior.NoAction)
					.HasConstraintName("FK_pin_code_attempts_bank_accounts");

				entity.HasData(SampleData.PinCodeAttempts);
			});
		}
	}
}

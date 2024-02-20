using Casher.Dal.Repos.Interfaces;

namespace Casher.Dal.EfStructures
{
    public class DataManager(
        IBankAccountRepo bankAccountRepo,
        IOperationRepo operationRepo,
        IOperationTypeRepo operationTypeRepo,
        IPinCodeAttemptRepo pinCodeAttemptRepo)
    {
        public IBankAccountRepo Accounts { get; set; } = bankAccountRepo;
        public IOperationRepo Operations { get; set; } = operationRepo;
        public IOperationTypeRepo OperationTypes { get; set; } = operationTypeRepo;
        public IPinCodeAttemptRepo PinCodeAttempts { get; set; } = pinCodeAttemptRepo;
    }
}

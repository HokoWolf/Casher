using Microsoft.EntityFrameworkCore;

namespace Casher.Exceptions
{
    public class NullMoneyAmountException : CustomException
    {
        public NullMoneyAmountException() { }
        public NullMoneyAmountException(string message) : base(message) { }
        public NullMoneyAmountException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}

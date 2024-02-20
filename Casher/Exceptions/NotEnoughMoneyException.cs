using Microsoft.EntityFrameworkCore;

namespace Casher.Exceptions
{
    public class NotEnoughMoneyException : CustomException
    {
        public NotEnoughMoneyException() { }
        public NotEnoughMoneyException(string message) : base(message) { }
        public NotEnoughMoneyException(string message, DbUpdateException innerException)
            : base(message, innerException) { }
    }
}

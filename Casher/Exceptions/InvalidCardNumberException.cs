using Microsoft.EntityFrameworkCore;

namespace Casher.Exceptions
{
    public class InvalidCardNumberException : CustomException
    {
        public InvalidCardNumberException() { }
        public InvalidCardNumberException(string message) : base(message) { }
        public InvalidCardNumberException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}

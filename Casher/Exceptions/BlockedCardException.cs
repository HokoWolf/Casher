namespace Casher.Exceptions
{
    public class BlockedCardException : CustomException
    {
        public BlockedCardException() { }
        public BlockedCardException(string message) : base(message) { }
        public BlockedCardException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}

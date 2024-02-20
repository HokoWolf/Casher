namespace Casher.Exceptions
{
    public class IncorrectPinCodeException : CustomException
    {
        public IncorrectPinCodeException() { }
        public IncorrectPinCodeException(string message) : base(message) { }
        public IncorrectPinCodeException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}

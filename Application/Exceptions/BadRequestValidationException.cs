namespace Application.Exceptions
{
    public class BadRequestValidationException : Exception
    {
        public BadRequestValidationException() : base("Validation Error.")
        {
        }

        public BadRequestValidationException(string? message) : base(message)
        {
        }
    }
}

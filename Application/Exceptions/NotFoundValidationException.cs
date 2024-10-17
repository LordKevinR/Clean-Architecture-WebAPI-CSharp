
namespace Application.Exceptions
{
    public class NotFoundValidationException : Exception
    {
        public NotFoundValidationException() : base("Validation Error.")
        {
        }

        public NotFoundValidationException(string? message) : base(message)
        {
        }
    }
}

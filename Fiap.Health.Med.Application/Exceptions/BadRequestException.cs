using FluentValidation.Results;

namespace Fiap.Health.Med.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message, ValidationResult validationResult) : base(message)
        {
            ValidationErrors = validationResult.ToDictionary();
        }

        public IDictionary<string, string[]> ValidationErrors { get; set; }

    }
}

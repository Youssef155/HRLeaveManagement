using FluentValidation.Results;

namespace HR.LeaveManagement.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(string message, ValidationResult validationResult) : base(message)
        {
            ValidatoinErrors = validationResult.ToDictionary();
        }

        public IDictionary<string, string[]> ValidatoinErrors { get; set; }
    }
}

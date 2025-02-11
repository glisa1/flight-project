using FlightProject.Shared;
using FluentValidation.Results;

namespace FlightProject.Application.Extensions;

internal static class ValidationErrorExtensions
{
    internal static IEnumerable<Error> GetErrors(this IEnumerable<ValidationFailure> validationResults)
    {
        return validationResults.Select(validation => new Error(validation.ErrorCode, validation.ErrorMessage, ErrorType.Validation));
    }
}

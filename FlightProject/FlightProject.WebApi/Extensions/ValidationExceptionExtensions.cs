using FluentValidation;

namespace FlightProject.WebApi.Extensions;

public static class ValidationExceptionExtensions
{
    public static IDictionary<string, string[]> AsProblemsDictionary(this ValidationException exception)
    {
        var groupResult = exception.Errors
            .GroupBy(error => error.PropertyName)
            .Select(group => KeyValuePair.Create(

                group.Key,
                new List<string>(group.Select(groupElement => groupElement.ErrorMessage)).ToArray()
            )).ToDictionary();

        return groupResult;
    }
}

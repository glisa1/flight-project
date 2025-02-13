﻿using FlightProject.Shared;

namespace FlightProject.WebApi.Extensions
{
    internal static class CustomResults
    {
        internal static IResult Problem(Result result)
        {
            if (result.IsSuccess)
            {
                throw new InvalidOperationException("Result has not failed.");
            }

            if (result.IsValidationErrorResult)
            {
                return Results.ValidationProblem(errors: GetErrors(result));
            }

            return Results.Problem(
                title: GetTitle(result.Error),
                detail: GetDescription(result.Error),
                statusCode: GetStatusCode(result.Error),
                type: GetType(result.Error.Type),
                extensions: null
                );
        }

        private static string GetTitle(Error error) =>
            error.Type switch
            {
                ErrorType.Failure => "Server failure",
                _ => error.Code
            };

        private static string GetDescription(Error error) =>
            error.Type switch
            {
                ErrorType.Failure => "Unexpected error occurred",
                _ => error.Description
            };

        private static int GetStatusCode(Error error) =>
            error.Type switch
            {
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError
            };

        private static string GetType(ErrorType errorType) =>
            errorType switch
            {
                ErrorType.Validation => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                ErrorType.Problem => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                ErrorType.NotFound => "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                ErrorType.Conflict => "https://tools.ietf.org/html/rfc7231#section-6.5.8",
                _ => "https://tools.ietf.org/html/rfc7231#section-6.6.1"
            };

        static Dictionary<string, string[]> GetErrors(Result result)
        {
            return result.ValidationErrors!.GroupBy(error => error.Code).ToDictionary(k => k.Key, v => v.Select(f => f.Description).ToArray());
        }
    }
}

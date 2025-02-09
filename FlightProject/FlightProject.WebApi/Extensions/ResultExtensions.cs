using FlightProject.Shared;

namespace FlightProject.WebApi.Extensions;

internal static class ResultExtensions
{
    internal static TOut Match<TOut>(
                this Result result,
                Func<TOut> OnSuccess,
                Func<Result, TOut> OnFailure
            )
    {
        return result.IsSuccess ? OnSuccess() : OnFailure(result);
    }

    internal static TOut Match<TIn, TOut>(
        this Result<TIn> result,
        Func<TIn, TOut> OnSuccess,
        Func<Result<TIn>, TOut> OnFailure
        )
    {
        return result.IsSuccess ? OnSuccess(result.Value) : OnFailure(result);
    }
}

using Sharpy.Core.Regex;

namespace Sharpy.Core.Parser.Results;

public class Error<Result> : Core.Errors.Error where Result : notnull
{
    public Error(Results<Result> results, string message = "") : base(message) => Results = results;

    public Results<Result> Results { get; init; }
}
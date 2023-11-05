using Sharpy.Core.Regex;

namespace Sharpy.Core.Processor.Results;

public class Error<Result> : Core.Errors.Error
{
    public Error(Results<Result> results, string message = "") : base(message) => Results = results;

    public Results<Result> Results { get; init; }
}
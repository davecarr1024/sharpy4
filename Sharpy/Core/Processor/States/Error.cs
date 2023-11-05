namespace Sharpy.Core.Processor.States;

public class Error<StateType, ResultsType, Result> : Core.Errors.Error
    where ResultsType : Results.Results<Result>
    where Result : notnull
{
    public Error(StateAndResults<StateType, ResultsType, Result> stateAndResults, string message = "") : base(message) => StateAndResults = stateAndResults;

    public StateAndResults<StateType, ResultsType, Result> StateAndResults { get; init; }
}
namespace Sharpy.Core.Processor.States;

public abstract record StateAndResults<StateType, ResultsType, Result>
    where ResultsType : Results.Results<Result>
    where Result : notnull
{
    protected StateAndResults(StateType state) => State = state;

    public StateType State { get; init; }

    public abstract ResultsType Results { get; init; }

    public StateAndNoResults<StateType, Result> No() => new(State);

    public abstract StateAndSingleResults<StateType, Result> Single();

    public abstract StateAndOptionalResults<StateType, Result> Optional();

    public abstract StateAndMultipleResults<StateType, Result> Multiple();

    public abstract StateAndNamedResults<StateType, Result> Named(string name = "");
}

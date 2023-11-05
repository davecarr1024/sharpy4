namespace Sharpy.Core.Processor.States;

public record StateAndOptionalResults<StateType, Result>
    : StateAndResults<StateType, Results.OptionalResults<Result>, Result>
    where Result : notnull
{
    public StateAndOptionalResults(StateType state, Results.OptionalResults<Result> results) : base(state) => Results = results;

    public StateAndOptionalResults(StateType state, Result result) : this(state, new Results.OptionalResults<Result>(result)) { }

    public StateAndOptionalResults(StateType state) : this(state, new Results.OptionalResults<Result>()) { }

    public override Results.OptionalResults<Result> Results { get; init; }

    public Result? Value => Results.Value;

    public override StateAndSingleResults<StateType, Result> Single()
        => Value switch
        {
            null => throw new Error<StateType, Results.OptionalResults<Result>, Result>(this),
            _ => new(State, Value),
        };

    public override StateAndOptionalResults<StateType, Result> Optional() => this;

    public override StateAndMultipleResults<StateType, Result> Multiple()
        => Value switch
        {
            null => new(State),
            _ => new(State, Value),
        };

    public override StateAndNamedResults<StateType, Result> Named(string name = "")
            => Value switch
            {
                null => new(State),
                _ => new(State, (name, Value)),
            };

    public StateAndSingleResults<StateType, Result> Convert(Func<Result?, Result> func) => new(State, Results.Convert(func));
}
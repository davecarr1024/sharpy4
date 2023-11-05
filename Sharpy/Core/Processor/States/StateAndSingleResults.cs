namespace Sharpy.Core.Processor.States;

public record StateAndSingleResults<StateType, Result>
    : StateAndResults<StateType, Results.SingleResults<Result>, Result>
    where Result : notnull
{
    public StateAndSingleResults(StateType state, Results.SingleResults<Result> results) : base(state) => Results = results;

    public StateAndSingleResults(StateType state, Result result) : this(state, new Results.SingleResults<Result>(result)) { }

    public override Results.SingleResults<Result> Results { get; init; }

    public Result Value => Results.Value;

    public override StateAndSingleResults<StateType, Result> Single() => this;

    public override StateAndOptionalResults<StateType, Result> Optional() => new(State, Value);

    public override StateAndMultipleResults<StateType, Result> Multiple() => new(State, Value);

    public override StateAndNamedResults<StateType, Result> Named(string name = "") => new(State, (name, Value));

    public StateAndSingleResults<StateType, Result> Convert(Func<Result, Result> func) => new(State, Results.Convert(func));
}
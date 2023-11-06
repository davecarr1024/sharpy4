namespace Sharpy.Core.Parser.States;

public record StateAndNoResults<StateType, Result>
    : StateAndResults<StateType, Results.NoResults<Result>, Result>
    where Result : notnull
{
    public StateAndNoResults(StateType state) : base(state) { }

    public override Results.NoResults<Result> Results { get; init; } = new();

    public override StateAndSingleResults<StateType, Result> Single() => throw new Error<StateType, Results.NoResults<Result>, Result>(this);

    public override StateAndOptionalResults<StateType, Result> Optional() => new(State);

    public override StateAndMultipleResults<StateType, Result> Multiple() => new(State);

    public override StateAndNamedResults<StateType, Result> Named(string name = "") => new(State);

    public StateAndSingleResults<StateType, Result> Convert(Func<Result> func) => new(State, Results.Convert(func));
}

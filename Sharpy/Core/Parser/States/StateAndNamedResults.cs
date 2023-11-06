namespace Sharpy.Core.Parser.States;

public record StateAndNamedResults<StateType, Result>
    : StateAndResults<StateType, Results.NamedResults<Result>, Result>
    where Result : notnull
{
    public StateAndNamedResults(StateType state, Results.NamedResults<Result> results) : base(state) => Results = results;

    public StateAndNamedResults(StateType state, params (string, Result)[] results) : this(state, new Results.NamedResults<Result>(results)) { }

    public override Results.NamedResults<Result> Results { get; init; }

    public Containers.Dictionary<string, Result> Values => Results.Values;

    public override StateAndSingleResults<StateType, Result> Single()
        => Values.Count switch
        {
            1 => new(State, Values.Values.First()),
            _ => throw new Error<StateType, Results.NamedResults<Result>, Result>(this)
        };

    public override StateAndOptionalResults<StateType, Result> Optional()
        => Values.Count switch
        {
            0 => new(State),
            1 => new(State, Values.Values.First()),
            _ => throw new Error<StateType, Results.NamedResults<Result>, Result>(this)
        };

    public override StateAndMultipleResults<StateType, Result> Multiple()
        => new(State, new Results.MultipleResults<Result>(Values.OrderBy(kv => kv.Key).Select(kv => kv.Value).ToArray()));

    public override StateAndNamedResults<StateType, Result> Named(string name = "") => this;

    public StateAndSingleResults<StateType, Result> Convert(Func<Containers.Dictionary<string, Result>, Result> func) => new(State, Results.Convert(func));
}
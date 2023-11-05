namespace Sharpy.Core.Processor.States;

public record StateAndMultipleResults<StateType, Result>
    : StateAndResults<StateType, Results.MultipleResults<Result>, Result>
    where Result : notnull
{
    public StateAndMultipleResults(StateType state, Results.MultipleResults<Result> results) : base(state) => Results = results;

    public StateAndMultipleResults(StateType state, params Result[] results) : this(state, new Results.MultipleResults<Result>(results)) { }

    public override Results.MultipleResults<Result> Results { get; init; }

    public Containers.List<Result> Values => Results.Values;

    public override StateAndSingleResults<StateType, Result> Single()
        => Values.Count switch
        {
            1 => new(State, Values[0]),
            _ => throw new Error<StateType, Results.MultipleResults<Result>, Result>(this),
        };

    public override StateAndOptionalResults<StateType, Result> Optional()
        => Values.Count switch
        {
            0 => new(State),
            1 => new(State, Values[0]),
            _ => throw new Error<StateType, Results.MultipleResults<Result>, Result>(this),
        };

    public override StateAndMultipleResults<StateType, Result> Multiple() => this;

    public override StateAndNamedResults<StateType, Result> Named(string name = "")
            => Values.Count switch
            {
                0 => new(State),
                1 => new(State, (name, Values[0])),
                _ => throw new Error<StateType, Results.MultipleResults<Result>, Result>(this),
            };

    public StateAndSingleResults<StateType, Result> Convert(Func<Containers.List<Result>, Result> func) => new(State, Results.Convert(func));
}
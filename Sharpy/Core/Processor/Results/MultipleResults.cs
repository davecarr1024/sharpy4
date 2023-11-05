namespace Sharpy.Core.Processor.Results;

public record MultipleResults<Result>(Containers.Set<Result> Value) : Results<Result>
{
    public MultipleResults(IImmutableSet<Result> values) : this(new Containers.Set<Result>(values)) { }

    public MultipleResults(params Result[] values) : this(new Containers.Set<Result>(values)) { }

    public override MultipleResults<Result> Multiple() => this;

    public override NoResults<Result> No() => new();

    public override OptionalResults<Result> Optional()
    => Value.Count switch
    {
        0 => new(),
        1 => new(Value.First()),
        _ => throw new Error<Result>(this, "unable to convert MultipleResults to OptionalResults"),
    };

    public override SingleResults<Result> Single()
    => Value.Count switch
    {
        1 => new(Value.First()),
        _ => throw new Error<Result>(this, "unable to convert MultipleResults to OptionalResults"),
    };

    public override NamedResults<Result> Named(string name = "")
    => Value.Count switch
    {
        0 => new(),
        1 => new((name, Value.First())),
        _ => throw new Error<Result>(this, "unable to convert MultipleResults to NamedResults"),
    };
}

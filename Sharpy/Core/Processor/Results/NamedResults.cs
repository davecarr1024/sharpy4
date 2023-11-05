namespace Sharpy.Core.Processor.Results;

public record NamedResults<Result>(Containers.Dictionary<string, Result> Values) : Results<Result>
{
    public NamedResults() : this(new Containers.Dictionary<string, Result>()) { }

    public NamedResults(IImmutableDictionary<string, Result> values) : this(new Containers.Dictionary<string, Result>(values)) { }

    public NamedResults(params (string name, Result value)[] values)
    : this(
        new Containers.Dictionary<string, Result>(
            ImmutableDictionary.CreateRange(
                values.Select(item => new KeyValuePair<string, Result>(item.name, item.value))
            )
        )
    )
    { }

    public override MultipleResults<Result> Multiple() => new(Values.Items.Values.ToImmutableHashSet());

    public override NamedResults<Result> Named(string name = "") => this;

    public override NoResults<Result> No() => new();

    public override OptionalResults<Result> Optional()
        => Values.Items.Count switch
        {
            0 => new(),
            1 => new(Values.Items.Values.First()),
            _ => throw new Error<Result>(this, "unable to convert NamedResults to OptionalResults"),
        };

    public override SingleResults<Result> Single()
        => Values.Items.Count switch
        {
            1 => new(Values.Items.Values.First()),
            _ => throw new Error<Result>(this, "unable to convert NamedResults to SingleResults"),
        };
}
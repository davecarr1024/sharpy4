namespace Sharpy.Core.Processor.Results;

public record MultipleResults<Result>(Containers.Set<Result> Values) : Results<Result> where Result : notnull
{
    public MultipleResults(params Result[] values) : this(new Containers.Set<Result>(values)) { }

    public override MultipleResults<Result> Multiple() => this;

    public override NoResults<Result> No() => new();

    public override OptionalResults<Result> Optional()
    => Values.Count switch
    {
        0 => new(),
        1 => new(Values.First()),
        _ => throw new Error<Result>(this, "unable to convert MultipleResults to OptionalResults"),
    };

    public override SingleResults<Result> Single()
    => Values.Count switch
    {
        1 => new(Values.First()),
        _ => throw new Error<Result>(this, "unable to convert MultipleResults to OptionalResults"),
    };

    public override NamedResults<Result> Named(string name = "")
    => Values.Count switch
    {
        0 => new(),
        1 => new((name, Values.First())),
        _ => throw new Error<Result>(this, "unable to convert MultipleResults to NamedResults"),
    };
}

namespace Sharpy.Core.Processor.Results;

public record OptionalResults<Result>(Result? Value) : Results<Result> where Result : notnull
{
    public OptionalResults() : this(default(Result)) { }

    public override NoResults<Result> No() => new();

    public override SingleResults<Result> Single()
        => Value switch
        {
            null => throw new Error<Result>(this, "unable to convert OptionalResult to SingleResult"),
            _ => new(Value),
        };

    public override OptionalResults<Result> Optional() => this;

    public override MultipleResults<Result> Multiple() => Value == null ? new() : new(Value);

    public override NamedResults<Result> Named(string name = "")
        => Value switch
        {
            null => new(),
            _ => new((name, Value)),
        };
}
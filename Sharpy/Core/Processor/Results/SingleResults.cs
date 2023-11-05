namespace Sharpy.Core.Processor.Results;

public record SingleResults<Result>(Result Value) : Results<Result>
{
    public override NoResults<Result> No() => new();

    public override SingleResults<Result> Single() => this;

    public override OptionalResults<Result> Optional() => new(Value);

    public override MultipleResults<Result> Multiple() => new(Value);

    public override NamedResults<Result> Named(string name = "") => new((name, Value));
}
namespace Sharpy.Core.Processor.Results;

public record NoResults<Result> : Results<Result>
{
    public override NoResults<Result> No() => this;

    public override SingleResults<Result> Single() => throw new Error<Result>(this, "unable to convert NoResults to SingleResult");

    public override OptionalResults<Result> Optional() => new();

    public override MultipleResults<Result> Multiple() => new();

    public override NamedResults<Result> Named(string name = "") => new();
}
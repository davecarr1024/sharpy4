namespace Sharpy.Core.Processor.Results;

public record SingleResults<Result>(Result Value) : Results<Result>
{
    public override NoResults<Result> No() => new();

    public override SingleResults<Result> Single() => this;

    public override OptionalResults<Result> Optional() => new(Value);

    public override MultipleResults<Result> Multiple() => new(Value);

    public override NamedResults<Result> Named(string name = "") => new((name, Value));

    public static SingleResults<Result> operator |(SingleResults<Result> lhs, NoResults<Result> _) => lhs;

    public static MultipleResults<Result> operator |(SingleResults<Result> lhs, SingleResults<Result> rhs) => new(lhs.Value, rhs.Value);

    public static MultipleResults<Result> operator |(SingleResults<Result> lhs, OptionalResults<Result> rhs)
        => new(lhs.Multiple().Value.Concat(rhs.Multiple().Value).ToImmutableHashSet());

    public static MultipleResults<Result> operator |(SingleResults<Result> lhs, MultipleResults<Result> rhs)
        => new(lhs.Multiple().Value.Concat(rhs.Value).ToImmutableHashSet());

    public static NamedResults<Result> operator |(SingleResults<Result> lhs, NamedResults<Result> rhs)
        => new(lhs.Named().Values.Concat(rhs.Values).ToImmutableDictionary());
}
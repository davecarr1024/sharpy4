namespace Sharpy.Core.Parser.Results;

public record NamedResults<Result>(Containers.Dictionary<string, Result> Values) : Results<Result> where Result : notnull
{
    public NamedResults(params (string name, Result value)[] values)
        : this(new Containers.Dictionary<string, Result>(values)) { }

    public override MultipleResults<Result> Multiple() => new(Values.OrderBy(kv => kv.Key).Select(kv => kv.Value).ToArray());

    public override NamedResults<Result> Named(string name = "") => this;

    public override NoResults<Result> No() => new();

    public override OptionalResults<Result> Optional()
        => Values.Count switch
        {
            0 => new(),
            1 => new(Values.Values.First()),
            _ => throw new Error<Result>(this, "unable to convert NamedResults to OptionalResults"),
        };

    public override SingleResults<Result> Single()
        => Values.Count switch
        {
            1 => new(Values.Values.First()),
            _ => throw new Error<Result>(this, "unable to convert NamedResults to SingleResults"),
        };

    public static NamedResults<Result> operator |(NamedResults<Result> lhs, NoResults<Result> _) => lhs;

    public static NamedResults<Result> operator |(NamedResults<Result> lhs, SingleResults<Result> rhs) => lhs | rhs.Named();

    public static NamedResults<Result> operator |(NamedResults<Result> lhs, OptionalResults<Result> rhs) => lhs | rhs.Named();

    public static NamedResults<Result> operator |(NamedResults<Result> lhs, MultipleResults<Result> rhs) => lhs | rhs.Named();

    public static NamedResults<Result> operator |(NamedResults<Result> lhs, NamedResults<Result> rhs) => new(lhs.Values | rhs.Values);

    public SingleResults<Result> Convert(Func<Containers.Dictionary<string, Result>, Result> func) => new(func(Values));
}
namespace Sharpy.Core.Processor.Results;

public record MultipleResults<Result>(Containers.List<Result> Values) : Results<Result> where Result : notnull
{
    public MultipleResults(params Result[] values) : this(new Containers.List<Result>(values)) { }

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

    public static MultipleResults<Result> operator |(MultipleResults<Result> lhs, NoResults<Result> _) => lhs;

    public static MultipleResults<Result> operator |(MultipleResults<Result> lhs, SingleResults<Result> rhs) => lhs | rhs.Multiple();

    public static MultipleResults<Result> operator |(MultipleResults<Result> lhs, OptionalResults<Result> rhs) => lhs | rhs.Multiple();

    public static MultipleResults<Result> operator |(MultipleResults<Result> lhs, MultipleResults<Result> rhs)
        => new(new Containers.List<Result>(lhs.Values.Concat(rhs.Values).ToArray()));

    public static NamedResults<Result> operator |(MultipleResults<Result> lhs, NamedResults<Result> rhs) => lhs.Named() | rhs;
}

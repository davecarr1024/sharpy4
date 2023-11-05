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

    public static OptionalResults<Result> operator |(OptionalResults<Result> lhs, NoResults<Result> _) => lhs;

    public static MultipleResults<Result> operator |(OptionalResults<Result> lhs, SingleResults<Result> rhs) => lhs.Multiple() | rhs.Multiple();

    public static MultipleResults<Result> operator |(OptionalResults<Result> lhs, OptionalResults<Result> rhs) => lhs.Multiple() | rhs.Multiple();

    public static MultipleResults<Result> operator |(OptionalResults<Result> lhs, MultipleResults<Result> rhs) => lhs.Multiple() | rhs;

    public static NamedResults<Result> operator |(OptionalResults<Result> lhs, NamedResults<Result> rhs) => lhs.Named() | rhs;

    public SingleResults<Result> Convert(Func<Result?, Result> func) => new(func(Value));
}
namespace Sharpy.Core.Parser.Results;

public record NoResults<Result> : Results<Result> where Result : notnull
{
    public override NoResults<Result> No() => this;

    public override SingleResults<Result> Single() => throw new Error<Result>(this, "unable to convert NoResults to SingleResult");

    public override OptionalResults<Result> Optional() => new();

    public override MultipleResults<Result> Multiple() => new();

    public override NamedResults<Result> Named(string name = "") => new();

    public static NoResults<Result> operator |(NoResults<Result> _, NoResults<Result> rhs) => rhs;

    public static SingleResults<Result> operator |(NoResults<Result> _, SingleResults<Result> rhs) => rhs;

    public static OptionalResults<Result> operator |(NoResults<Result> _, OptionalResults<Result> rhs) => rhs;

    public static MultipleResults<Result> operator |(NoResults<Result> _, MultipleResults<Result> rhs) => rhs;

    public static NamedResults<Result> operator |(NoResults<Result> _, NamedResults<Result> rhs) => rhs;

    public SingleResults<Result> Convert(Func<Result> func) => new(func());
}

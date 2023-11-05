namespace Sharpy.Core.Regex;

public class Result
{
    public Result() { }

    public Result(IImmutableList<Chars.Char> chars) => Chars = chars;

    public override bool Equals(object? obj) => obj is Result rhs && Chars.SequenceEqual(rhs.Chars);

    public override int GetHashCode() => Chars.GetHashCode();

    public IImmutableList<Chars.Char> Chars { get; init; } = ImmutableList.Create<Chars.Char>();

    public Chars.Position Position() => Chars.Any() ? Chars[0].Position : new();

    public Tokens.Token Token(string ruleName) => Tokens.Token.Load(ruleName, Chars);

    public static Result Load(string value, Chars.Position? position = null)
        => new(Core.Chars.Stream.Load(value, position).Items);
}
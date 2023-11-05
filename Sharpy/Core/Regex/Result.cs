namespace Sharpy.Core.Regex;

public class Result : Streams.Set<Chars.Char>
{
    public Result() { }

    public Result(IImmutableList<Chars.Char> chars) : base(chars) { }

    public Result(string value, Chars.Position? position = null) : this(new Chars.Stream(value, position).Items) { }

    public static Result operator +(Result lhs, Result rhs) => new(lhs.Items.Concat(rhs.Items).ToImmutableList());

    public Chars.Position Position() => Items.Any() ? Items[0].Position : new();

    public Tokens.Token Token(string ruleName) => new(ruleName, Items);
}
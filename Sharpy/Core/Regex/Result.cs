namespace Sharpy.Core.Regex;

public class Result : Containers.List<Chars.Char>
{
    public Result() { }

    public Result(IImmutableList<Chars.Char> chars) : base(chars) { }

    public Result(string value, Chars.Position? position = null) : this(new Chars.Stream(value, position)) { }

    public static Result operator +(Result lhs, Result rhs) => new(lhs.Concat(rhs).ToImmutableList());

    public Chars.Position Position() => Items.Any() ? Items[0].Position : new();

    public Tokens.Token Token(string ruleName) => new(ruleName, Items);
}
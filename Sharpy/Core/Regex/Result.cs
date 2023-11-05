
namespace Sharpy.Core.Regex;

public class Result : Containers.List<Chars.Char>
{
    public Result(params Chars.Char[] items) : base(items) { }

    public Result(string value, Chars.Position? position = null)
        : this(new Chars.Stream(value, position).ToArray()) { }

    public static Result operator +(Result lhs, Result rhs)
        => new(lhs.Concat(rhs).ToArray());

    public Chars.Position Position()
        => Items.Any() ? Items[0].Position : new();

    public Tokens.Token Token(string ruleName)
        => new(ruleName, Items);
}
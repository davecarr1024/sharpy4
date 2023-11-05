namespace Sharpy.Core.Tokens;

public record Token(string RuleName, string Value, Chars.Position Position)
{
    public Token(string ruleName, string value) : this(ruleName, value, new()) { }

    public Token(string ruleName, IEnumerable<Chars.Char> chars, Chars.Position? position = null)
        : this(
            ruleName,
            string.Concat(chars.Select(char_ => char_.Value)),
            position ?? (chars.Any() ? chars.First().Position : new()))
    { }

    public Token(string ruleName, Chars.Stream value, Chars.Position? position = null)
        : this(ruleName, value.Items, position) { }
}
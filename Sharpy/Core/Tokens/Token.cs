namespace Sharpy.Core.Tokens;

public record Token(string RuleName, string Value, Chars.Position Position)
{
    public static Token Load(string ruleName, IEnumerable<Chars.Char> chars, Chars.Position? position = null)
        => new(
            ruleName,
            string.Concat(chars.Select(char_ => char_.Value)),
            position ?? (chars.Any() ? chars.First().Position : new()));

    public static Token Load(string ruleName, Chars.Stream value, Chars.Position? position = null)
        => Load(ruleName, value.Items, position);
}
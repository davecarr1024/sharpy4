namespace Sharpy.Core.Lexer;

public record Result(Tokens.Token Token)
{
    public Result(string ruleName, string value) : this(new Tokens.Token(ruleName, value)) { }
}
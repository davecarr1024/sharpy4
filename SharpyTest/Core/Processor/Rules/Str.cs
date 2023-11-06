namespace Sharpy.Core.Processor.Rules;

public record Str(string Value) : Val
{
    public static Lexer.Rule LexerRule => new("str", @"\""(^\"")\""");

    public static SingleResultsLiteral<States.LexerState, Val> Rule
        => new(LexerRule, token => new Str(token.Value.Trim('"')));
}
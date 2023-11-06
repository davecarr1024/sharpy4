namespace Sharpy.Core.Parser.Rules;

public record Int(int Value) : Val
{
    public static Lexer.Rule LexerRule => new("int", @"\d+");

    public static SingleResultsLiteral<States.LexerState, Val> Rule
        => new(LexerRule, token => new Int(int.Parse(token.Value)));
}
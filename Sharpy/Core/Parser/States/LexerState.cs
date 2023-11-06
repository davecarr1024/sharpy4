
namespace Sharpy.Core.Parser.States;


public record LexerState(Tokens.Stream Tokens) : ILexerState<LexerState>
{
    public LexerState() : this(new Tokens.Stream()) { }

    public LexerState(params (string name, string value)[] tokens) : this(new Tokens.Stream(tokens)) { }

    public LexerState(params Tokens.Token[] tokens) : this(new Tokens.Stream(tokens)) { }

    LexerState ILexerState<LexerState>.CreateTail(Tokens.Stream tokens) => new(tokens);
}

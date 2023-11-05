namespace Sharpy.Core.Lexer;

public record State(Chars.Stream Chars)
{
    public State(string value, Chars.Position? position = null) : this(new Chars.Stream(value, position)) { }

    public State() : this(new Chars.Stream()) { }
}
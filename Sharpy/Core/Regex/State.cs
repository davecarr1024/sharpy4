namespace Sharpy.Core.Regex;

public record State
{
    public State() { }

    public State(Chars.Stream chars) => Chars = chars;

    public State(string value, Chars.Position? position = null) : this(new Chars.Stream(value, position)) { }

    public Chars.Stream Chars { get; init; } = new();

    public Chars.Char Head => Chars.Head;

    public State Tail => new(Chars.Tail);
}
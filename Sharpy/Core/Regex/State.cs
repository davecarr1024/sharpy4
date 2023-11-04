namespace Sharpy.Core.Regex;

public record State(Chars.Stream Chars)
{
    public Chars.Char Head() => Chars.Head();

    public State Tail() => new(Chars.Tail());
}
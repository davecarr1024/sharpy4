namespace Sharpy.Core.Parser.States;

public record AbstractLexerState<Self>
    where Self : AbstractLexerState<Self>, new()
{
    public AbstractLexerState(Tokens.Stream tokens) => Tokens = tokens;

    public AbstractLexerState() : this(new Tokens.Stream()) { }

    public Tokens.Stream Tokens { get; init; }

    public Self Tail() => new() { Tokens = Tokens.Tail() };

    public Tokens.Token Head() => Tokens.Head();
}
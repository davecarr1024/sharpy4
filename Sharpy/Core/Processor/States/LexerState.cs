namespace Sharpy.Core.Processor.States;

public record LexerState(Tokens.Stream Tokens)
{
    public LexerState() : this(new Tokens.Stream()) { }
}
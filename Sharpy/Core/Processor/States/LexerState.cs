namespace Sharpy.Core.Processor.States;

public record LexerState : AbstractLexerState<LexerState>
{
    public LexerState(Tokens.Stream tokens) : base(tokens) { }

    public LexerState(params Tokens.Token[] tokens) : this(new Tokens.Stream(tokens)) { }

    public LexerState(params (string name, string value)[] tokens) : this(new Tokens.Stream(tokens)) { }

    public LexerState() : this(Array.Empty<(string, string)>()) { }
}
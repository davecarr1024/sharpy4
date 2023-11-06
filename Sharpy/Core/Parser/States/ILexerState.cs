

namespace Sharpy.Core.Parser.States;

public interface ILexerState<Self> where Self : ILexerState<Self>
{
    public Tokens.Stream Tokens { get; }

    public Tokens.Token Head => Tokens.Head;

    protected Self CreateTail(Tokens.Stream tokens);

    public Self Tail => CreateTail(Tokens.Tail);
}
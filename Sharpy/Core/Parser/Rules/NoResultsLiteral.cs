
namespace Sharpy.Core.Parser.Rules;

public record NoResultsLiteral<StateType, Result>(Lexer.Rule LexerRule, Action<Tokens.Token> Func)
    : Rule<StateType, Results.NoResults<Result>, Result>
    where StateType : States.AbstractLexerState<StateType>, new()
    where Result : notnull
{
    public NoResultsLiteral(Lexer.Rule lexerRule) : this(lexerRule, _ => { }) { }

    public override Lexer.Lexer Lexer => new(LexerRule);

    public override States.StateAndResults<StateType, Results.NoResults<Result>, Result> Call(StateType state)
    {
        try
        {
            if (state.Tokens.Head().RuleName == LexerRule.Name)
            {
                Func(state.Head());
                return new States.StateAndNoResults<StateType, Result>(state.Tail());
            }
        }
        catch (Core.Errors.Error error)
        {
            throw CreateError(state, error);
        }
        throw CreateError(state, "failed to match expected token");
    }
}
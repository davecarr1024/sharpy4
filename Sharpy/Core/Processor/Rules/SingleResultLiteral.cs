namespace Sharpy.Core.Processor.Rules;

public record SingleResultsLiteral<StateType, Result>(Lexer.Rule LexerRule, Func<Tokens.Token, Result> Func)
    : Rule<StateType, Results.SingleResults<Result>, Result>
    where StateType : States.AbstractLexerState<StateType>, new()
    where Result : notnull
{
    public override States.StateAndResults<StateType, Results.SingleResults<Result>, Result> Call(StateType state, Scope<StateType, Result> scope)
    {
        try
        {
            if (state.Tokens.Head().RuleName == LexerRule.Name)
            {
                return new States.StateAndSingleResults<StateType, Result>(state.Tail(), Func(state.Head()));
            }
        }
        catch (Core.Errors.Error error)
        {
            throw CreateError(state, error);
        }
        throw CreateError(state, "failed to match expected token");
    }
}
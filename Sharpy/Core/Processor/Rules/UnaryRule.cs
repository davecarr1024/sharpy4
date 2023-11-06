
namespace Sharpy.Core.Processor.Rules;

public abstract record UnaryRule<StateType, ResultsType, ChildResultsType, Result>
    : Rule<StateType, ResultsType, Result>
    where ResultsType : Results.Results<Result>
    where ChildResultsType : Results.Results<Result>
    where Result : notnull
{
    protected UnaryRule(Rule<StateType, ChildResultsType, Result> child) => Child = child;

    public Rule<StateType, ChildResultsType, Result> Child { get; init; }

    public override Lexer.Lexer Lexer => Child.Lexer;

    protected States.StateAndResults<StateType, ChildResultsType, Result> CallChild(StateType state, Scope<StateType, Result> scope)
    {
        try
        {
            return Child.Call(state, scope);
        }
        catch (Core.Errors.Error error)
        {
            throw CreateError(state, error);
        }
    }
}
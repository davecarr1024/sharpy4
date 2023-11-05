namespace Sharpy.Core.Processor.Rules;

public record ZeroOrMore<StateType, ChildResultsType, Result>
    : UnaryRule<StateType, Results.MultipleResults<Result>, ChildResultsType, Result>
    where ChildResultsType : Results.Results<Result>
    where Result : notnull
{
    public ZeroOrMore(Rule<StateType, ChildResultsType, Result> child) : base(child) { }

    public override States.StateAndResults<StateType, Results.MultipleResults<Result>, Result> Call(StateType state, Scope<StateType, Result> scope)
    {
        Results.MultipleResults<Result> results = new();
        while (true)
        {
            try
            {
                States.StateAndMultipleResults<StateType, Result> childStateAndResults = CallChild(state, scope).Multiple();
                state = childStateAndResults.State;
                results |= childStateAndResults.Results;
            }
            catch (Core.Errors.Error)
            {
                return new States.StateAndMultipleResults<StateType, Result>(state, results);
            }
        }
    }
}
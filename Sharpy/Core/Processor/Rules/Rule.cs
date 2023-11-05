namespace Sharpy.Core.Processor.Rules;

public abstract record Rule<StateType, ResultsType, Result>
    where ResultsType : Results.Results<Result>
    where Result : notnull
{
    public abstract States.StateAndResults<StateType, ResultsType, Result> Call(StateType state, Scope<StateType, Result> scope);

    protected Error<StateType, ResultsType, Result> Error(StateType state, string message) => new(this, state, message);

    protected Error<StateType, ResultsType, Result> Error(StateType state, params Core.Errors.Error[] children) => new(this, state, children);
}
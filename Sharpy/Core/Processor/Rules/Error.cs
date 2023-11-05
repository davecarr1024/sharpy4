using Sharpy.Core.Regex;

namespace Sharpy.Core.Processor.Rules;

public class Error<StateType, ResultsType, Result>
    : Core.Errors.NaryError
    where ResultsType : Results.Results<Result>
    where Result : notnull
{
    private Error(Rule<StateType, ResultsType, Result> rule, StateType state, string message, params Core.Errors.Error[] children)
        : base(message, children)
    {
        Rule = rule;
        State = state;
    }

    public Error(Rule<StateType, ResultsType, Result> rule, StateType state, string message) : this(rule, state, message, Array.Empty<Core.Errors.Error>()) { }

    public Error(Rule<StateType, ResultsType, Result> rule, StateType state, params Core.Errors.Error[] children) : this(rule, state, "", children) { }

    public Rule<StateType, ResultsType, Result> Rule { get; init; }

    public StateType State { get; init; }
}
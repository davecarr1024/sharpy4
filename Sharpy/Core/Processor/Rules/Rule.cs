namespace Sharpy.Core.Processor.Rules;

public abstract record Rule<StateType, ResultsType, Result>
    where ResultsType : Results.Results<Result>
    where Result : notnull
{
    public class Error : Core.Errors.NaryError
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

    public abstract States.StateAndResults<StateType, ResultsType, Result> Call(StateType state, Scope<StateType, Result> scope);

    protected Error CreateError(StateType state, string message) => new(this, state, message);

    protected Error CreateError(StateType state, params Core.Errors.Error[] children) => new(this, state, children);
}
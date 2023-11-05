namespace Sharpy.Core.Regex;

public record OneOrMore : UnaryRegex
{
    public OneOrMore(Regex Child) : base(Child)
    {
    }

    public override StateAndResult Call(State state)
    {
        Result result;
        try
        {
            StateAndResult child_state_and_result = Child.Call(state);
            state = child_state_and_result.State;
            result = child_state_and_result.Result;
        }
        catch (Errors.Error error)
        {
            throw new Error(this, error);
        }
        while (true)
        {
            try
            {
                StateAndResult child_state_and_result = Child.Call(state);
                state = child_state_and_result.State;
                result += child_state_and_result.Result;
            }
            catch (Errors.Error)
            {
                return new(state, result);
            }
        }
    }
}
namespace Sharpy.Core.Regex;

public record ZeroOrMore : UnaryRegex
{
    public ZeroOrMore(Regex Child) : base(Child)
    {
    }

    public override StateAndResult Call(State state)
    {
        Result result = new();
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
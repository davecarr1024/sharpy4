using Sharpy.Core.Streams;

namespace Sharpy.Core.Regex;

public record And : NaryRegex
{
    public And(params Regex[] children) : base(children) { }

    public override StateAndResult Call(State state)
    {
        Result result = new();
        foreach (Regex child in Children.Items)
        {
            try
            {
                StateAndResult child_state_and_result = child.Call(state);
                state = child_state_and_result.State;
                result += child_state_and_result.Result;
            }
            catch (Errors.Error error)
            {
                throw new Error(this, error);
            }
        }
        return new(state, result);
    }
}
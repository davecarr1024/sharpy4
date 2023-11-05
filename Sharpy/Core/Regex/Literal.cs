namespace Sharpy.Core.Regex;

public record Literal(char Value) : Regex
{
    public override StateAndResult Call(State state)
    {
        try
        {
            if (state.Head().Value == Value)
            {
                return new(state.Tail(), new Result(state.Head()));
            }
        }
        catch (Errors.Error error)
        {
            throw new Error(this, error);
        }
        throw new Error(this, $"expected char {Value} but got {state}");
    }
}